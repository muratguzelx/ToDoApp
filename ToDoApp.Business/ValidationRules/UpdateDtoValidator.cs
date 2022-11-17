using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ToDoApp.Dtos;

namespace ToDoApp.Business.ValidationRules
{
    public class UpdateDtoValidator : AbstractValidator<UpdateDto>
    {
        public UpdateDtoValidator()
        {
            RuleFor(x=>x.Definition ).NotEmpty();
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
