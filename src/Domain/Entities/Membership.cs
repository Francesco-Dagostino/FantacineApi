using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Membership
    {
        public int MembershipId { get; set; }
        public DateTime Date {  get; set; }
        public decimal Payment { get; set; }
        public SubscriptionType Type { get; set; }

        public int UserId { get; set; } // Clave foránea
        public virtual User User { get; set; } // Relación con User

        public Membership() { }
    }
}
