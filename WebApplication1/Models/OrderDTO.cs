using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class OrderDTO
    {
        [Key]
        public int Id { get; set; }
        public String orderItemName { get; set; }
        public String orderDesc { get; set; }
        public int CustId { get; set; }
        public CustomerDTO Customer { get; set; }
    }
}