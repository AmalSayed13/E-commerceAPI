using Dtos.Product;
using E_commerceAPI.BL.Dtos.Category;
using E_commerceAPI.BL.Dtos.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceAPI.BL.Managers.Categories
{
    public interface ICategoryManager
    {
     void AddCategory(AddCategoryDto addCategoryDto);
      IEnumerable<AddCategoryDto> GetAllCategories();
    }
}
