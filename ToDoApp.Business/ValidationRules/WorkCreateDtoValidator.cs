using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ToDoApp.Dtos;

namespace ToDoApp.Business.ValidationRules
{
    public class WorkCreateDtoValidator : AbstractValidator<WorkCreateDto>
    {
        public WorkCreateDtoValidator()
        {
            RuleFor(x=>x.Definition).NotEmpty().WithMessage("Definition alanı boş olmamalı.");
        }
    }
}
