
using E_commerceAPI.DAL.Data.Context;
using E_commerceAPI.DAL.Repositories.CartItems;
using E_commerceAPI.DAL.Repositories.Orders;
using E_commerceAPI.DAL.Repositories.Products;
using E_commerceAPI.DAL.Repositories.Category;

namespace HospsitalManagement.DAL;

public class UnitOfWork : IUnitOfWork
{
    private readonly EcommerceContext _context;

    public ICartItemRepository CartItemRepository { get; }
    public IOrderRepository OrderRepository { get; }
    public IProductRepository ProductRepository { get; }
    public ICategoryRepository CategoryRepository { get; }

    public UnitOfWork(IProductRepository productRepository,
        IOrderRepository orderRepository,
        ICartItemRepository cartItemRepository,
        ICategoryRepository categoryRepository,
        EcommerceContext context)
    {
        ProductRepository = productRepository;
        OrderRepository = orderRepository;
        CartItemRepository = cartItemRepository;
        _context = context;
        CategoryRepository = categoryRepository;
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
