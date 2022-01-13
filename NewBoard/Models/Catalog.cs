using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewBoard.Models;

namespace NewBoard.Models
{
    public class Catalog
    {
        public int CatalogId { get; set; }
        public string Name { get; set; }

        public ICollection<Thread> Threads { get; set; }
    }
}