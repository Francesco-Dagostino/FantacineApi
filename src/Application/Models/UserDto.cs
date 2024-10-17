﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class UserCreateRequest
    {
        [Required(ErrorMessage = "The Name must be complete")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "The password must be at least 20 characters long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Email must be complete")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "The password must be at least 20 characters long")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The password must be completed")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "The password must be at least 8 characters long")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }

    public class UserUpdateRequest
    {
        [StringLength(20, MinimumLength = 2, ErrorMessage = "The name must be between 2 and 20 characters long")]
        public string Name { get; set; }

        [StringLength(20, MinimumLength = 8, ErrorMessage = "The password must be at least 8 characters long")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}