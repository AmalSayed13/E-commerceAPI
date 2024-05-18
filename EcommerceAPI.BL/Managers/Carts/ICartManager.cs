using E_commerceAPI.BL.Dtos.Cart;

namespace E_commerceAPI.BL.Managers.Carts
{
    public interface ICartManager
    {
        void AddToCart(int productId, int quantity);
        void RemoveFromCart(int productId);
        void EditCartItemQuantity(int productId, int quantity);
        CartDto GetCart();
        void ClearCart();

    }
}
