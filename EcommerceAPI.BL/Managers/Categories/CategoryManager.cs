using Dtos.Product;
using E_commerceAPI.BL.Dtos.Category;
using E_commerceAPI.DAL.Data.Models;
using HospsitalManagement.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceAPI.BL.Managers.Categories
{
    public class CategoryManager : ICategoryManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddCategory(AddCategoryDto addCategoryDto)
        {
            var category = _unitOfWork.CategoryRepository.GetByName(addCategoryDto.Name);
            if (category != null)
            {
                throw new ArgumentException($"Sorry!! Category {addCategoryDto.Name} is already exist");
            }
            var CategoryEntity = new Category
            {
                Name = addCategoryDto.Name,
                Description = addCategoryDto.Description,
            };
            _unitOfWork.CategoryRepository.Add(CategoryEntity);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<AddCategoryDto> GetAllCategories()
        {
            var categories = _unitOfWork.CategoryRepository.GetAll()
                      .Select(p => new AddCategoryDto
                      {
                          Name = p.Name,
                         Description = p.Description
                      });

            return categories;
        }
    }
}
