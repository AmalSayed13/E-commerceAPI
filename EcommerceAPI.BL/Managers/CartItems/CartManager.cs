using Dtos.Product;
using E_commerceAPI.BL.Dtos.Cart;
using E_commerceAPI.DAL.Data.Models;
using E_commerceAPI.DAL.Data.Models.Enums;
using E_commerceAPI.DAL.Repositories.CartItems;
using E_commerceAPI.DAL.Repositories.Products;
using E_commerceAPI.DAL.Repositorries.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceAPI.BL.Managers.CartItems
{
    public class CartManager : ICartManager
    {
        private readonly ICartItemRepository _cartItemRepository;

        public CartManager(ICartItemRepository cartItemRepository )
        {
            _cartItemRepository = cartItemRepository;
           
        }

        public void AddToCart(int productId, int quantity)
        {
            _cartItemRepository.AddToCart(productId, quantity);
            

        }

        public void EditCartItemQuantity(int productId, int quantity)
        {
            _cartItemRepository.EditCartItemQuantity(productId, quantity);
        }

        public IEnumerable<CartItemReadDto> GetALL()
        {
            var CartItems = _cartItemRepository.GetAll()
                    .Select(p => new CartItemReadDto
                    {
                        ID= p.ID,
                        ProductID = p.ProductId,
                        Quantity= p.Quantity,
                        Price= p.Price,
                    });


            return CartItems;
        }

        public Product? GetByProductId(int id)
        {
           return _cartItemRepository.GetByProductId(id);
        }

        public void RemoveFromCart(int productId)
        {
            _cartItemRepository.RemoveFromCart(productId);
        }
    }
}
