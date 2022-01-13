using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewBoard.Models;

namespace NewBoard.Models
{
    public class Thread
    {
        public int ThreadId { get; set; }
        public Catalog Catalog { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}