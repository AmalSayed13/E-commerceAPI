using E_commerceAPI.DAL.Data.Models;
using E_commerceAPI.DAL.Repositorries.Generic;

namespace E_commerceAPI.DAL.Repositories.CartItems
{
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
        void AddToCart(int productId, int quantity);
        void RemoveFromCart(int productId);
        void EditCartItemQuantity(int productId, int quantity);
        Product? GetByProductId(int productId);
    }
}
