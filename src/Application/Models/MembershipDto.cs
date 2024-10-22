using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;

namespace Application.Models
{
    public class MembershipCreateRequest
    {
        [Required(ErrorMessage = "The Date is required.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "The Payment is required.")]
        public decimal Payment { get; set; }

        [Required(ErrorMessage = "The SubscriptionType is required.")]
        public SubscriptionType  Type { get; set; }

        [Required(ErrorMessage = "The UserId is required.")]
        public int  UserId { get; set; }
    }

    public class MembershipUpdateRequest
    {
        [Required]
        public SubscriptionType  Type { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public decimal Payment { get; set; }
        [Required(ErrorMessage = "The UserId is required.")]
        public int UserId { get; set; }
    }
}
