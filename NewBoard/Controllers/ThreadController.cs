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

        public ActionResult Index()
        {
            return View(_context.Threads.ToList());
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
        public ActionResult Post(PostThreadViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Show", new { id = viewModel.ThreadId });

            var thread = _context.Threads
                .Include(t => t.Posts)
                .FirstOrDefault(t => t.ThreadId == viewModel.ThreadId);

            var post = new Post
            {
                Message = viewModel.Post.Message
                    .Replace(Environment.NewLine, "<br>")
                    .Replace("\r\n", "<br>"),
                Thread = thread,
                Timestamp = DateTime.Now
            };

            _context.Posts.Add(post);
            _context.SaveChanges();
            //var m = post.PostId;
            //var newThread = new Thread { ThreadId = post.PostId, Catalog = new Catalog() };
            return RedirectToAction("Show", new { id = viewModel.ThreadId });
        }
    }
}