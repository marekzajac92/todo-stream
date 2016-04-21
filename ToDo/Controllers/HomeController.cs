using System.Web.Mvc;
using ToDo.Services.Interfaces;

namespace ToDo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskService _taskService;

        public HomeController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public ActionResult Index()
        {
            var vm = _taskService.GetTasks();
            
            return View(vm);
        }
    }
}