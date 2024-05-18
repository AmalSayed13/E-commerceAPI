using E_commerceAPI.DAL.Repositories.CartItems;
using E_commerceAPI.DAL.Repositories.Orders;
using E_commerceAPI.DAL.Repositories.Products;
using E_commerceAPI.DAL.Repositories.Category;
using E_commerceAPI.DAL.Repositorries.CartItems;


namespace HospsitalManagement.DAL;

public interface IUnitOfWork
{
    public ICartRepository CartRepository { get; }
    public IOrderRepository OrderRepository { get; }
    public IProductRepository ProductRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    public ICartItemRepository CartItemRepository { get; }

    void SaveChanges();
}
