﻿using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Membership
    {
        public int MembershipId { get; set; }
        public DateTime Date {  get; set; }
        public decimal Payment { get; set; }
        public SubscriptionType Type { get; set; }

        public Membership() { }
    }
}
