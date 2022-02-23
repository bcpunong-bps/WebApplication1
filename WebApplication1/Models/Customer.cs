using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Customer
    {
        [Key]
        public int CustId { get; set; }
        public String CustName { get; set; }

    }



}