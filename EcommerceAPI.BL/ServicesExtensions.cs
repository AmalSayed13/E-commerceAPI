using E_commerceAPI.BL.Managers.CartItems;
using E_commerceAPI.BL.Managers.Products;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceAPI.BL
{
    public static class ServicesExtensions
{
        public static void AddBLServices(this IServiceCollection services)
        {
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<ICartManager, CartManager>();

        }
    }
}
