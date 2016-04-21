using System;
using FluentValidation;
using ToDo.ViewModels;

namespace ToDo.Helpers.Validators
{
    public class CreateTaskViewModelValidator : AbstractValidator<CreateTaskViewModel>
    {
        public CreateTaskViewModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Required");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Required");
        }
    }
}