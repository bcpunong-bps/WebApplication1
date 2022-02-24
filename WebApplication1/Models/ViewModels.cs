using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ViewModels
    {

        public IEnumerable<Customer> Customers { set; get; }
        public IEnumerable<Order> Orders { get; set; }



    }
}