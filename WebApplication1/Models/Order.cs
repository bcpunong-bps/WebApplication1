﻿using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string OrderName { get; set; }
        public string OrderDescription { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}