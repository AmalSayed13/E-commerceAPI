using Dtos.Product;
using E_commerceAPI.BL.Dtos.Product;
using E_commerceAPI.DAL.Data.Models;
using System.Collections.Generic;

namespace E_commerceAPI.BL.Managers.Products
{
    public interface IProductManager
    {
        IEnumerable<ProductReadDto> GetProducts(string? category, string? name);
        public ProductDetailsDto? GetById(int id);
       public void AddProduct(ProductDto product);
        public void DeleteProduct(int id);
        public void UpdateProduct(int id, ProductDto product);
    }
}
