using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

            var vm = new HomeViewModel()
            {
                YesterdayTasks = GetTasksForDate(tasks, DateTime.Now.AddDays(-1).Date).Select(taskToTaskViewModel).ToList(),
                TodayTasks = GetTasksForDate(tasks, DateTime.Now.Date).Select(taskToTaskViewModel).ToList(),
                TomorrowTasks = GetTasksForDate(tasks, DateTime.Now.AddDays(1).Date).Select(taskToTaskViewModel).ToList(),
            };

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

        private IEnumerable<Task> GetTasksForDate(IEnumerable<Task> tasks ,DateTime date)
        {
            return tasks.Where(x => x.Date.Date == date.Date);
        }

        private TaskViewModel taskToTaskViewModel(Task task)
        {
            return new TaskViewModel()
            {
                Id = task.Id,
                IsDone = task.IsDone,
                Description = task.Description,
                Name = task.Name
            };
        }

        private Task createTaskViewModelToTask(CreateTaskViewModel vm)
        {
            return new Task()
            {
                IsDone = false,
                Date = vm.Date,
                Description = vm.Description,
                Name = vm.Name
            };
        }
    }
}
