using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToDoApp.Business.Interfaces;
using ToDoApp.Business.Mapping.AutoMapper;
using ToDoApp.Business.Services;
using ToDoApp.Business.ValidationRules;
using ToDoApp.DataAccess.Contexts;
using ToDoApp.DataAccess.UnitOfWork;
using ToDoApp.Dtos;

namespace ToDoApp.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {

            services.AddDbContext<ToDoContext>(opt =>
            {
                opt.UseSqlServer("server=(localdb)\\mssqllocaldb; database=TodoDb; integrated security = true;");
            });
            // Mapper ekleme ile ilgili configurations
            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new WorkProfile());
            });
            var mapper = configuration.CreateMapper();
            //Buraya kadar.

            services.AddSingleton(mapper);
            services.AddScoped<IworkService, WorkService>();
            services.AddScoped<IUow, Uow>();
            services.AddTransient<IValidator<WorkCreateDto>, WorkCreateDtoValidator>();
            services.AddTransient<IValidator<UpdateDto>, UpdateDtoValidator>();

        }
    }
}
