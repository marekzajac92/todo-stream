﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDo.Models
{
    public class Task
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
        public virtual Category Category { get; set; } 
    }
}