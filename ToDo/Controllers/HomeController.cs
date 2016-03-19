using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class HomeController : Controller
    {
        private ToDoDbContext _context;

        public HomeController()
        {
            _context = new ToDoDbContext();
        }

        public ActionResult Index()
        {
            var model =
                _context.Tasks.ToList();
            model = model.Where(
                x =>
                    x.Date.Date >= (DateTime.Now.Date.AddDays(-1)) &&
                    x.Date.Date <= (DateTime.Now.Date.AddDays(1))).ToList();
            return View(model);
        }
    }
}