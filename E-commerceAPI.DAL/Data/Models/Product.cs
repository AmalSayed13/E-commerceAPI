using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_commerceAPI.DAL.Data.Models.Enums;

namespace E_commerceAPI.DAL.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }= string.Empty;
        public int Rate { get; set; }
        public string? ImageUrl { get; set; } 
        public string Description { get; set; } = string.Empty;
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        public int Count { get; set; }
        //one of product in category
        [Required]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        //product has many of cart item
        public ICollection<CartItem> CartItems { get; set; } = [];
        
        //product has many of order items
        public ICollection<OrderItem> OrderItems { get; set; } = [];
   
    }
}
