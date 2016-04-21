using System.Data.Entity;
using System.Web.Mvc;
using ToDo.Models;
using ToDo.Services;
using ToDo.Services.Interfaces;
using ToDo.ViewModels;

namespace ToDo.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateTaskViewModel task)
        {
            if (!ModelState.IsValid)
            {
                return View(task);
            }
            _taskService.Create(task);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Remove(int? id)
        {
            _taskService.Remove(id);
            
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Done(int? id)
        {
            _taskService.Done(id);

            return RedirectToAction("Index", "Home");
        }
    }
}