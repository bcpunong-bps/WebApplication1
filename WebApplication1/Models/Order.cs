using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Order
    {

        public int orderId { get; set; }
        public String orderItemName { get; set; }
        public String orderItemDesc { get; set; }
    }
}