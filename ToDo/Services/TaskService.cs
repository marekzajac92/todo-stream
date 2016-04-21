using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using ToDo.Models;
using ToDo.Services.Interfaces;
using ToDo.ViewModels;

namespace ToDo.Services
{
    public class TaskService : ITaskService
    {
        private readonly ToDoDbContext _context;

        public TaskService()
        {
            _context = new ToDoDbContext();
        }

        public HomeViewModel GetTasks()
        {
            var tasks = _context.Tasks.ToList();

            var vm = Mapper.Map<HomeViewModel>(tasks);

            return vm;
        }

        public void Create(CreateTaskViewModel task)
        {
            var entity = createTaskViewModelToTask(task);

            _context.Tasks.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(int? id)
        {
            var task = GetTask(id);
            if (task == null) return;

            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }

        public void Done(int? id)
        {
            var task = GetTask(id);
            if (task == null) return;

            task.IsDone = true;
            _context.Entry(task).State = EntityState.Modified;
            _context.SaveChanges();
        }

        private Task GetTask(int? id)
        {
            return _context.Tasks.Find(id);
        }

        private Task createTaskViewModelToTask(CreateTaskViewModel vm)
        {
            return Mapper.Map<Task>(vm);
        }
    }
}
