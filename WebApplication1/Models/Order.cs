using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Order
    {

      
        public int orderId { get; set; }
        public String orderItemName { get; set; }
        public String orderDesc { get; set; }
    }
}