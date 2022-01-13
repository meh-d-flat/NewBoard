using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NewBoard.Models;

namespace NewBoard.Models
{
    public class Post
    {
        public int PostId { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime Timestamp { get; set; }

        public Thread Thread { get; set; }
    }
}