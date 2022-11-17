using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Common.ResponseObjects;
using ToDoApp.Dtos;
using ToDoApp.Dtos.Interfaces;

namespace ToDoApp.Business.Interfaces
{
    public interface IworkService
    {
        Task<IResponse<List<WorkListDto>>> GetAll();
        Task<IResponse<WorkCreateDto>> Create(WorkCreateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id); 
        Task<IResponse> Remove(int id);
        Task<IResponse<UpdateDto>> Update(UpdateDto dto);
    }
}
