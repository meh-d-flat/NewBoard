using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewBoard.Models;

namespace NewBoard.Models
{
    public class Thread
    {
        ApplicationDbContext _context;

        public int ThreadId { get; set; }

        public Catalog Catalog { get; set; }

        public ICollection<Post> Posts { get; set; }

        public Thread()
        {
            _context = new ApplicationDbContext();
        }

        public Post GetOp()
        {
            return _context.Posts.Where(p => p.Thread.ThreadId == ThreadId).FirstOrDefault();
        }

        public int PostsNumber()
        {
            return _context.Posts.Where(p => p.Thread.ThreadId == ThreadId).Count();
        }
    }
}