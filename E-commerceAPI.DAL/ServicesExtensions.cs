using E_commerceAPI.DAL.Data.Context;
using E_commerceAPI.DAL.Repositories.CartItems;
using E_commerceAPI.DAL.Repositories.Category;
using E_commerceAPI.DAL.Repositories.Orders;
using E_commerceAPI.DAL.Repositories.Products;
using E_commerceAPI.DAL.Repositorries.CartItems;
using HospsitalManagement.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace E_commerceAPI.DAL
{
    public static class ServicesExtensions
    {
        public static void AddDALServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ECommerceDb");
            services.AddDbContext<EcommerceContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICartItemRepository, CartItemRepository>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
