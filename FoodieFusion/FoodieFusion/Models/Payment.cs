﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FoodieFusion.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string Name { get; set; }
        public string ExpiryDate { get; set; }
        public string Address { get; set; }
        public string PaymentMode { get; set; }

        [NotMapped]
        public List<Payment> PaymentList { get; set; }
    }
}