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

        public CustomerContext() : base("CustomerContext")
        {


        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            modelBuilder.Entity<Customer>().Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Customer>().Property(c => c.Name).HasMaxLength(64);

            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Order>().HasKey(c => c.Id);
            modelBuilder.Entity<Order>().Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Order>().Property(c => c.OrderName).HasMaxLength(64);
            modelBuilder.Entity<Order>()
                 .HasRequired(c => c.Customer)
                 .WithMany()
                 .HasForeignKey(d => d.CustomerId);
        }
    }
}