using NewBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using NewBoard.ViewModels;

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
            var thread = _context.Threads
                .Include(t => t.Posts)
                .FirstOrDefault(t => t.ThreadId == id);

            var viewModel = new PostThreadViewModel
            {
                ThreadId = id,
                Thread = thread
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Post(PostThreadViewModel postThreadViewModel)
        {
            if (postThreadViewModel.Post.PostId == 0)
            {
                var thread = _context.Threads
                    .Include(t => t.Posts)
                    .FirstOrDefault(t => t.ThreadId == postThreadViewModel.ThreadId);

                postThreadViewModel.Post.Thread = thread;
                postThreadViewModel.Post.Timestamp = DateTime.Now;

                _context.Posts.Add(postThreadViewModel.Post);
            }

            _context.SaveChanges();

            return RedirectToAction("Show", new { id = postThreadViewModel.ThreadId });
        }
    }
}