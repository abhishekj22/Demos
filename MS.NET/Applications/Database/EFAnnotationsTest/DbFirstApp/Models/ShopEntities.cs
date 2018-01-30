using System;
using System.Collections.Generic;

namespace DbFirstApp.Models
{
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("OrderDetail")]
    public class Order
    {
        [Column("OrderNo")]
        public int Id { get; set; }

        [Display(Name = "Order Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MMM-dd}")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Customer ID")]
        public string CustomerId { get; set; }

        [Column("ProductNo")]
        [ScaffoldColumn(false)]
        public int ProductId { get; set; }

        public int Quantity { get; set; }   
    }

    [Table("Product")]
    public class Product
    {
        [Column("ProductNo")]
        [Display(Name = "Product No")]
        public int Id { get; set; }

        [Display(Name = "Unit Price")]
        [Required]
        public decimal Price { get; set; }

        [Display(Name = "Current Stock")]
        [Required][Range(5, 50)]
        public int Stock { get; set; }

        //non-virtual navigation property - requires explicit loading
        public ICollection<Order> Orders { get; set; }  
    }

    public class ShopEntities : DbContext
    {
        public ShopEntities() : base(Properties.Settings.Default.ShopConnectionString)
        {                
        }

        public DbSet<Product> Products { get; set; }    
    }
}