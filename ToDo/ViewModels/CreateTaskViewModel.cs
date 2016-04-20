using System;
using System.ComponentModel.DataAnnotations;

namespace ToDo.ViewModels
{
    public class CreateTaskViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
}