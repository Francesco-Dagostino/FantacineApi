using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Movie
    {
        public string Category { get; set; }
        public int Duration { get; set;  }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
