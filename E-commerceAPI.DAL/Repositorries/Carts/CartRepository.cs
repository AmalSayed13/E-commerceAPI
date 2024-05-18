using E_commerceAPI.DAL.Data.Context;
using E_commerceAPI.DAL.Data.Models;
using E_commerceAPI.DAL.Repositorries.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace E_commerceAPI.DAL.Repositories.CartItems
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartRepository(EcommerceContext context, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Cart GetByUserId(string userId)
        {
            return _context.Carts.FirstOrDefault(c => c.UserId == userId)!;
        }

        public void AddToCart(int productId, int quantity)
        {
            var product = _context.Products.Find(productId);
            if (product == null)
            {
                throw new ArgumentException($"Product with id {productId} not found");
            }

            var cart = _context.Carts.FirstOrDefault(c => c.UserId == GetUserId()); 
            {
                cart = new Cart { UserId = GetUserId() }; 
                _context.Carts.Add(cart);
            }

            var cartItem = cart.CartItems.FirstOrDefault(item => item.ProductId == productId);
            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
            }
            else
            {
                cart.CartItems.Add(new CartItem
                {
                    ProductId = productId,
                    Quantity = quantity,
                    Price = product.Price,
                    CreatedDate = DateTime.UtcNow
                });
            }

            _context.SaveChanges();
        }

        public void RemoveFromCart(int productId)
        {
            var cart = _context.Carts.FirstOrDefault(c => c.UserId == GetUserId()); 
            if (cart == null)
            {
                throw new ArgumentException("Cart not found for the user");
            }

            var cartItem = cart.CartItems.FirstOrDefault(item => item.ProductId == productId);
            if (cartItem == null)
            {
                throw new ArgumentException($"Product with id {productId} not found in the cart");
            }

            cart.CartItems.Remove(cartItem);
            _context.SaveChanges();
        }

        public void EditCartItemQuantity(int productId, int quantity)
        {
            var cart = _context.Carts.FirstOrDefault(c => c.UserId == GetUserId());
            {
                throw new ArgumentException("Cart not found for the user");
            }

           
            var cartItem = cart.CartItems.FirstOrDefault(item => item.ProductId == productId);
            if (cartItem == null)
            {
                throw new ArgumentException($"Product with id {productId} not found in the cart");
            }

            cartItem.Quantity = quantity;
            _context.SaveChanges();
        }

        public Product GetByProductId(int productId)
        {
            return _context.Products.Find(productId)!;
        }
        private string GetUserId()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
        }
    }
}
