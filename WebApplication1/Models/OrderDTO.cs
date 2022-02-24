using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string OrderName { get; set; }
        public string OrderDescription { get; set; }
        public int CustomerId { get; set; }
        public CustomerDTO CustomerDTO { get; set; }
    }

}