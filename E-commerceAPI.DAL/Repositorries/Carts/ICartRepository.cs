using E_commerceAPI.DAL.Data.Models;
using E_commerceAPI.DAL.Repositorries.Generic;

namespace E_commerceAPI.DAL.Repositories.CartItems
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        public void AddToCart(int productId, int quantity);
        public void RemoveFromCart(int productId);
        public void EditCartItemQuantity(int productId, int quantity);
        public Product GetByProductId(int productId);
        public Cart GetByUserId(string userId);


    }
}
