using E_commerceAPI.DAL.Data.Context;
using E_commerceAPI.DAL.Data.Models;
using E_commerceAPI.DAL.Repositorries.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace E_commerceAPI.DAL.Repositories.CartItems
{
    public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(EcommerceContext context) : base(context)
        {
        }

        public void AddToCart(int productId, int quantity)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);

            //var existingCartItem = _context.CartItems.FirstOrDefault(c => c.ProductID == productId);
            //if (existingCartItem != null)
            //{
            //    existingCartItem.Quantity += quantity;
            //    existingCartItem.Price = quantity * product.Price;
            //    _context.SaveChanges();

            //}
           if(product != null)
            {
                var cartItem = new CartItem { ProductId = productId, Quantity = quantity, Price = (product.Price * quantity) };
                _context.CartItems.Add(cartItem);
            }
                _context.SaveChanges();

           
        }

        public void RemoveFromCart(int productId)
        {
            var cartItem = _context.CartItems.FirstOrDefault(c => c.ProductId == productId);
            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
            }
            _context.SaveChanges();
        }

        public void EditCartItemQuantity(int productId, int quantity)
        {
            var product = _context.Products.Find(productId);
            var cartItem = _context.CartItems.FirstOrDefault(c => c.ProductId == productId);
            if (cartItem != null && product != null)
            {
                cartItem.Quantity = quantity;
                cartItem.Price = quantity * product.Price;

            }
            _context.SaveChanges();
        }

        public Product? GetByProductId(int productId)
        {
            return _context.Products.FirstOrDefault(c => c.Id == productId);
        }
    }
}
