using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
    
        public int Id {  get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage = "The name must be completed")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The name must between 2 and 50 characters long")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The email must be completed")]
        [EmailAddress(ErrorMessage = "Must be a valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The name must be completed")]
        [MinLength(8, ErrorMessage = "The password must be at least 8 characters long")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public Roles Role { get; set; } // Aquí utilizamos el enum

        public User() { }
    }
}
