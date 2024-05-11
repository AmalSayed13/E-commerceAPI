using E_commerceAPI.DAL.Data.Models;
using E_commerceAPI.DAL.Repositorries.Generic;
using System.Collections.Generic;

namespace E_commerceAPI.DAL.Repositories.Products
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IEnumerable<Product> GetProducts(string? category, string? name);
    }
}
