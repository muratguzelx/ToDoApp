using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ToDoApp.Dtos;
using ToDoApp.Entities.Domains;

namespace ToDoApp.Business.Mapping.AutoMapper
{
    public class WorkProfile : Profile
    {
        public WorkProfile()
        {
            CreateMap<Work, WorkListDto>().ReverseMap();
            CreateMap<Work, WorkCreateDto>().ReverseMap();
            CreateMap<Work, UpdateDto>().ReverseMap();
            CreateMap<WorkListDto, UpdateDto>().ReverseMap();


        }
    }
}
