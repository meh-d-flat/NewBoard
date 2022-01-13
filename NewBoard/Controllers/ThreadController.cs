using NewBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace NewBoard.Controllers
{
    public class ThreadController : Controller
    {
        ApplicationDbContext _context;

        public ThreadController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Thread
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult Show(int id)
        {
            var thread = _context.Threads.Include(t => t.Posts).FirstOrDefault(t => t.ThreadId == id);
            return View(thread);
        }
    }
}