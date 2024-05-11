using E_commerceAPI.DAL.Repositories.CartItems;
using E_commerceAPI.DAL.Repositories.Orders;
using E_commerceAPI.DAL.Repositories.Products;
using E_commerceAPI.DAL.Repositories.Category;


namespace HospsitalManagement.DAL;

public interface IUnitOfWork
{
    public ICartItemRepository CartItemRepository { get; }
    public IOrderRepository OrderRepository { get; }
    public IProductRepository ProductRepository { get; }
    public ICategoryRepository CategoryRepository { get; }

    void SaveChanges();
}
