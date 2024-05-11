using E_commerceAPI.BL.Dtos.Cart;
using E_commerceAPI.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceAPI.BL.Managers.CartItems
{
    public interface ICartManager
    {
        void AddToCart(int productId, int quantity);
        IEnumerable<CartItemReadDto> GetALL();
        void RemoveFromCart(int productId);
        Product? GetByProductId(int id);
        void EditCartItemQuantity(int productId, int quantity);
    } 
}

