using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class TaskController : Controller
    {
        private ToDoDbContext _context;

        public TaskController()
        {
            _context = new ToDoDbContext();
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Task task)
        {
            if (!ModelState.IsValid)
            {
                return View(task);
            }
            task.IsDone = false;
            _context.Tasks.Add(task);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Remove(int? id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Done(int? id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                task.IsDone = true;
                _context.Entry(task).State = EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}