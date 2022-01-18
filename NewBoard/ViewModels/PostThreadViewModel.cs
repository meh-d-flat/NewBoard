using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewBoard.Models;

namespace NewBoard.ViewModels
{
    public class PostThreadViewModel
    {
        public int ThreadId { get; set; }

        public int PostId { get; set; }

        public Thread Thread { get; set; }

        public Post Post { get; set; }
    }
}