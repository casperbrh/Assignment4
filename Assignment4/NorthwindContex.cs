using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Assignment4
{
    public class NorthwindContex : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("host=localhost;db=northwind;uid=postgres;pwd=RucRuc13");
            //optionsBuilder.UseLoggerFactory(MyLoggerFactory)
                //.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Map class property: Category
            modelBuilder.Entity<Category>().ToTable("categories");
            modelBuilder.Entity<Category>().Property(x => x.Id).HasColumnName("categoryid");
            modelBuilder.Entity<Category>().Property(x => x.Name).HasColumnName("categoryname");
            modelBuilder.Entity<Category>().Property(x => x.Description).HasColumnName("description");

            // Map class property: Product
            modelBuilder.Entity<Product>().Property(x => x.Id).HasColumnName("ProductId");
            modelBuilder.Entity<Product>().Property(x => x.Name).HasColumnName("ProductName");
            modelBuilder.Entity<Product>().Property(x => x.QuantityPerUnit).HasColumnName("QuantityUnit");
        
            // Map class property: Order 
            modelBuilder.Entity<Order>().Property(x => x.Id).HasColumnName("OrderId");
            modelBuilder.Entity<Order>().Property(x => x.Date).HasColumnName("OrderDate");
            modelBuilder.Entity<Order>().Property(x => x.Required).HasColumnName("RequiredDate");

            // Map class property: Order Details
            modelBuilder.Entity<OrderDetails>().HasKey(x => new { x.OrderId, x.ProductId });

            modelBuilder.Entity<OrderDetails>()
                .HasOne(x => x.Order)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.OrderId);

            modelBuilder.Entity<OrderDetails>()
                .HasOne(x => x.Product)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.ProductId);

            
       }

        /*public static readonly LoggerFactory MyLoggerFactory
            = new LoggerFactory(new[]
            {
                new ConsoleLoggerProvider((category, level)
                    => category == DbLoggerCategory.Database.Command.Name
                       && level == LogLevel.Information, true)
            });*/
    }
}
