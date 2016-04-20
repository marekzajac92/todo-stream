using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDo.Models;
using ToDo.Services;
using ToDo.Services.Interfaces;
using ToDo.ViewModels;

namespace ToDo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskService _taskService;

        public HomeController()
        {
            _taskService = new TaskService();
        }

        public ActionResult Index()
        {
            var vm = _taskService.GetTasks();
            
            return View(vm);
        }
    }
}