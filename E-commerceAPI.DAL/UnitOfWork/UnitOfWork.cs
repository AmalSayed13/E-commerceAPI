
using E_commerceAPI.DAL.Data.Context;
using E_commerceAPI.DAL.Repositories.CartItems;
using E_commerceAPI.DAL.Repositories.Orders;
using E_commerceAPI.DAL.Repositories.Products;
using E_commerceAPI.DAL.Repositories.Category;
using E_commerceAPI.DAL.Repositorries.CartItems;

namespace HospsitalManagement.DAL;

public class UnitOfWork : IUnitOfWork
{
    private readonly EcommerceContext _context;

    public ICartRepository CartRepository { get; }
    public IOrderRepository OrderRepository { get; }
    public IProductRepository ProductRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    public ICartItemRepository CartItemRepository { get; }

    public UnitOfWork(IProductRepository productRepository,
        IOrderRepository orderRepository,
        ICartRepository cartRepository,
        ICategoryRepository categoryRepository,
        ICartItemRepository cartItemRepository,
        EcommerceContext context)
    {
        ProductRepository = productRepository;
        OrderRepository = orderRepository;
        CartRepository = cartRepository;
        _context = context;
        CategoryRepository = categoryRepository;
        CartItemRepository= cartItemRepository;
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
