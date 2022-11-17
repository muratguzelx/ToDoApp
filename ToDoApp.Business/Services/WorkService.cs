using AutoMapper;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Business.Interfaces;
using ToDoApp.Common.ResponseObjects;
using ToDoApp.DataAccess.UnitOfWork;
using ToDoApp.Dtos;
using ToDoApp.Dtos.Interfaces;
using ToDoApp.Entities.Domains;

namespace ToDoApp.Business.Services
{
    public class WorkService : IworkService
    {
        private IUow _uow;
        private IMapper _mapper;
        private IValidator<UpdateDto> _updateValidator;
        private IValidator<WorkCreateDto> _createValidator;

        public WorkService(IUow uow, IMapper mapper, IValidator<UpdateDto> updateValidator,
            IValidator<WorkCreateDto> createValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _updateValidator = updateValidator;
            _createValidator = createValidator;
        }

        public async Task<IResponse<WorkCreateDto>> Create(WorkCreateDto dto)
        {
            var validationResult = _createValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Work>().Create(_mapper.Map<Work>(dto));
                await _uow.SaveChanges();
                return new Response<WorkCreateDto>(ResponseType.Success, dto);
            }
            else
            {
                List<CustomValidationError> errors = new List<CustomValidationError>();
                foreach (var error in validationResult.Errors)
                {
                    errors.Add(new()
                    {
                        ErrorMessage = error.ErrorMessage,
                        PropertyName = error.PropertyName
                    });
                }

                return new Response<WorkCreateDto>(ResponseType.ValidationError, dto, errors);
            }
        }

        public async Task<IResponse<List<WorkListDto>>> GetAll()
        {
            var data = _mapper.Map<List<WorkListDto>>(await _uow.GetRepository<Work>().GetAll());
            return new Response<List<WorkListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data =  _mapper.Map<IDto>(await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id));
            if (data==null)
            {
                return new Response<IDto>(ResponseType.NotFound, "Id ye ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntity = await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id);
            if (removedEntity != null)
            {
                _uow.GetRepository<Work>().Remove(removedEntity);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }

            return new Response(ResponseType.NotFound, "Id ye ait kayıt bulunmadı");
        }

        public async Task<IResponse<UpdateDto>> Update(UpdateDto dto)
        {
            var validatorResult = _updateValidator.Validate(dto);
            if (validatorResult.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<Work>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<Work>().Update(_mapper.Map<Work>(dto), updatedEntity);
                    await _uow.SaveChanges();
                    return new Response<UpdateDto>(ResponseType.Success, dto);
                }
                return new Response<UpdateDto>(ResponseType.NotFound, "İlgili id ye ait kayıt bulunamadı.");
            }
            else
            {
                List<CustomValidationError> errors = new List<CustomValidationError>();
                foreach (var error in validatorResult.Errors)
                {
                    errors.Add(new()
                    {
                        ErrorMessage = error.ErrorMessage,
                        PropertyName = error.PropertyName
                    });
                }

                return new Response<UpdateDto>(ResponseType.ValidationError, dto, errors);
            }
            
        }
    }
}
