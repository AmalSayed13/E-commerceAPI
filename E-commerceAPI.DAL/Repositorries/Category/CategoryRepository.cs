using E_commerceAPI.DAL.Data.Context;
using E_commerceAPI.DAL.Data.Models;
using E_commerceAPI.DAL.Repositories.Products;
using E_commerceAPI.DAL.Repositorries.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceAPI.DAL.Repositories.Category
{
    public class CategoryRepository : GenericRepository<Data.Models.Category>, ICategoryRepository
    {
        public CategoryRepository(EcommerceContext context) : base(context)
        {
        }

        public Data.Models.Category? GetByName(string name)
        {
            return _context.Categories.FirstOrDefault(c => c.Name == name);
        }

    }
}
