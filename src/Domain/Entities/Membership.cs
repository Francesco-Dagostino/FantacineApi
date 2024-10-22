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
        [Key]  // Anotación para definir la clave primaria
        public int MembershipId { get; set; }
        public DateTime Date {  get; set; }
        public decimal Payment { get; set; }
        public SubscriptionType Type { get; set; }
    
        public Membership() { }

         public int UserId { get; set; }  // Foreign Key a User
        public User User { get; set; }   // Navegación de la entidad User
    }
}
