using System;
using System.Collections.Generic;

namespace DbFirstApp
{
    using System.Data.Entity;

    public class InvoiceEntry
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public string CustomerId { get; set; }

        public int ProductNo { get; set; }

        public int Quantity { get; set; }

        public decimal Amount { get; set; } 
    }

    public class Customer
    {
        public string CustomerId { get; set; }

        public decimal Credit { get; set; }

        //virtual navigation property - supports automatic lazy loading
        public virtual ICollection<InvoiceEntry> InvoiceEntries { get; set; }   
    }


    public class ShopEntities : DbContext
    {
        public ShopEntities() : base(Properties.Settings.Default.ShopConnectionString)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<InvoiceEntry> InvoiceEntries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceEntry>()
                .ToTable("Invoice")
                .Property(p => p.Id)
                .HasColumnName("OrderNo");

            modelBuilder.Entity<Customer>()
                .ToTable("Customer");
        }
    }
}
