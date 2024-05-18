using E_commerceAPI.DAL.Data.Models;
using E_commerceAPI.DAL.Data.Models.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace E_commerceAPI.DAL.Data.Context
{
    public class EcommerceContext : IdentityDbContext<User>
    {
       
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }

        public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
       .HasOne(u => u.Cart)
       .WithOne(c => c.User)
       .HasForeignKey<Cart>(c => c.UserId);


            // Seeding data
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Electronics", Description = "Electronics category description" },
                new Category { Id = 2, Name = "Laptops", Description = "Laptops category description" }
            };

            modelBuilder.Entity<Category>().HasData(categories);

            var products = new List<Product>
            {
                new Product { Id = 1, Name = "SAMSUNG Galaxy S24 Ultra", Rate = 5, Description = "AI Android Smartphone, 512GB Storage, 12GB RAM, 200MP Camera, S Pen, Long Battery Life - Titanium Gray", Price = 66666, Count = 10, CategoryId = 1 },
                new Product { Id = 2, Name = "Apple 2022 MacBook", Rate = 4, Description = "Apple 2022 MacBook Air laptop with M2 chip: 13.6-inch Liquid Retina display, 8GB RAM, 256GB SSD storage, 1080p FaceTime HD camera. Works with iPhone and iPad; Space Grey; ", Price = 59750, Count = 5, CategoryId = 2 }
            };

            modelBuilder.Entity<Product>().HasData(products);

            var users = new List<User>
            {
                new User { Id = "1", UserName = "user1", Email = "user1@example.com", Age = 30, Address = "123 Street, City", Gender = Gender.Male },
                new User { Id = "2", UserName = "user2", Email = "user2@example.com", Age = 25, Address = "456 Avenue, Town", Gender = Gender.Female }
            };

            modelBuilder.Entity<User>().HasData(users);

            var carts = new List<Cart>
{
            new Cart { ID = 1, UserId = "1" },
            new Cart { ID = 2, UserId = "2" }
};

            modelBuilder.Entity<Cart>().HasData(carts);

            var cartItems = new List<CartItem>
{
    new CartItem { ID = 1, Quantity = 1, Price = 66666, CreatedDate = DateTime.Now, CartId = 1, ProductId = 1 },
    new CartItem { ID = 2, Quantity = 1, Price = 59750, CreatedDate = DateTime.Now, CartId = 1, ProductId = 2 },
    new CartItem { ID = 3, Quantity = 1, Price = 66666, CreatedDate = DateTime.Now, CartId = 2, ProductId = 1 },
    new CartItem { ID = 4, Quantity = 1, Price = 59750, CreatedDate = DateTime.Now, CartId = 2, ProductId = 2 }
};

            modelBuilder.Entity<CartItem>().HasData(cartItems);


            var orders = new List<Order>
            {
                new Order { ID = 1, TotalPrice = 2500, CreatedDateTime = DateTime.Now, UserId = "1" },
                new Order { ID = 2, TotalPrice = 3500, CreatedDateTime = DateTime.Now, UserId = "2" }
            };

            modelBuilder.Entity<Order>().HasData(orders);

            var orderItems = new List<OrderItem>
            {
                new OrderItem { Id = 1, PriceTotal = 66666, OrderId = 1, ProductId = 1 },
                new OrderItem { Id = 2, PriceTotal = 59750, OrderId = 2, ProductId = 2 }
            };

            modelBuilder.Entity<OrderItem>().HasData(orderItems);
        }
    }
}
