using System;
using FluentValidation.Attributes;
using ToDo.Helpers.Validators;

namespace ToDo.ViewModels
{
    [Validator(typeof(CreateTaskViewModelValidator))]
    public class CreateTaskViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
}