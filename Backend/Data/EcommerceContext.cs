using System;
using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data

{
	public class EcommerceContext : DbContext
	{

		public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options)
		{
		}

		public DbSet<Admin> Admins{get; set;}
        public DbSet<Cart_item> Cart_Items { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Order_detail> Order_Details { get; set; }
        public DbSet<Order_item> Order_Items { get; set; }
        public DbSet<Payment_detail> Payment_Details { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Product_category> Product_Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Shopping_session> Shopping_Sessions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().ToTable("Admin");

            modelBuilder.Entity<Cart_item>().ToTable("Cart_item");
            modelBuilder.Entity<Cart_item>().HasOne(p => p.Shopping_session).WithMany(b => b.Cart_items).HasForeignKey(p => p.shopping_session_id);
            modelBuilder.Entity<Cart_item>().HasOne(p => p.Product).WithMany(b => b.Cart_items).HasForeignKey(p => p.product_id);
            
            modelBuilder.Entity<Discount>().ToTable("Discount");

            modelBuilder.Entity<Order_detail>().ToTable("Order_detail").HasOne(b => b.Payment_detail).WithOne(i => i.Order_detail).HasForeignKey<Payment_detail>(b => b.order_detail_id).IsRequired(false);

            modelBuilder.Entity<Order_item>().ToTable("Order_Item");
            modelBuilder.Entity<Order_item>().HasOne(p => p.Order_detail).WithMany(b => b.Order_items).HasForeignKey(p => p.order_detail_id);

            modelBuilder.Entity<Payment_detail>().ToTable("Payment_detail");

            modelBuilder.Entity<Product>().ToTable("Product").HasOne(p => p.Product_category).WithMany(b => b.Products).HasForeignKey(p => p.product_category_id);
            modelBuilder.Entity<Product>().HasOne(p => p.Discount).WithMany(b => b.Products).HasForeignKey(p => p.discount_id);
            
            modelBuilder.Entity<Product>().HasOne(b => b.Order_item).WithOne(i => i.Product).HasForeignKey<Order_item>(b => b.product_id).IsRequired(false);

            modelBuilder.Entity<Product_category>().ToTable("Product_category");

            modelBuilder.Entity<Review>().ToTable("Review");
            modelBuilder.Entity<Review>().HasOne(p => p.Product).WithMany(b => b.Reviews).HasForeignKey(p => p.product_id);
            modelBuilder.Entity<Review>().HasOne(p => p.User).WithMany(b => b.Reviews).HasForeignKey(p => p.user_id);

            modelBuilder.Entity<Shopping_session>().ToTable("Shopping_session");
            

            modelBuilder.Entity<User>().ToTable("User").HasOne(b => b.Order_detail).WithOne(i => i.User).HasForeignKey<Order_detail>(b => b.user_id).IsRequired(false);
            modelBuilder.Entity<User>().HasOne(b => b.Shopping_session).WithOne(i => i.User).HasForeignKey<Shopping_session>(b => b.user_id).IsRequired(false);
        }
    }
}

