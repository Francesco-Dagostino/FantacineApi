using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class MovieCreateRequest
    {
        ///[Required]
        //public int MovieId { get; set; }
        [Required]
        public Genre Category { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
    }

    public class MovieUpdateRequest
    {
        [Required]
        public Genre Category { get; set; } 
        [Required]
        public int Duration { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
       
        
    }
}
