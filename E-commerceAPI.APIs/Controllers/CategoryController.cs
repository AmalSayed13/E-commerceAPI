using Dtos.Product;
using E_commerceAPI.BL.Dtos.Category;
using E_commerceAPI.BL.Managers.Categories;
using E_commerceAPI.BL.Managers.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_commerceAPI.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager _categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var Categories = _categoryManager.GetAllCategories();
                return Ok(Categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        [Authorize(Policy = "AdminsOnly")]
        public ActionResult AddCategory(AddCategoryDto addCategoryDto)
        {
            try
            {
                _categoryManager.AddCategory(addCategoryDto);
                return Ok("Category added successfully");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
