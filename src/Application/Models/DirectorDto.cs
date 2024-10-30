using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class DirectorCreateRequest
    {


        [Required(ErrorMessage = "The Name is required.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "The Name must be between 2 and 20 characters long.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Description is required.")]
        public string Description { get; set; }


    }

    public class DirectorUpdateRequest
    {
        [Required(ErrorMessage = "The Name must be complete")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "The password must be at least 20 characters long")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public int DirectorId { get; set; }
    }
}
