using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Movie
    {
        public int MovieId { get; set; }
        public  Genre Category { get; set; }
        public int Duration { get; set;  }
        public string Title { get; set; }
        public string Description { get; set; }
        public int DirectorId {  get; set; }  
        public Director Director { get; set; }
        
        
        public Movie() { }
    }
}
