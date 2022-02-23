using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebApplication1.Models;

namespace WebApplication1.Context
{
    public class CustomerContext : DbContext
    {

        public CustomerContext() : base ("CustomerContext")
          {


          }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Customer>().HasKey(c => c.CustId);
            modelBuilder.Entity<Customer>().Property(c => c.CustId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Customer>().Property(c => c.CustName).HasMaxLength(64);
        }


    }
                  



}