using Dtos.Product;
using E_commerceAPI.BL.Dtos.Product;
using E_commerceAPI.DAL.Data.Models;
using HospsitalManagement.DAL;
using Microsoft.AspNetCore.Http;


namespace E_commerceAPI.BL.Managers.Products
{
    public class ProductManager : IProductManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ProductDetailsDto GetById(int id)
        {
            var product = _unitOfWork.ProductRepository.GetById(id);
            if (product == null)
            {
                throw new ArgumentException($"Product with id {id} not found");
            }

            var category = _unitOfWork.CategoryRepository.GetById(product.CategoryId);
            var categoryName = category != null ? category.Name : "Unknown";

            return new ProductDetailsDto
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                ImageFile = product.ImageUrl,
                CategoryName = categoryName,
                Rate = product.Rate,
                Count = product.Count
            };
        }

        public void AddProduct(ProductDto productDto)
        {
            var category = _unitOfWork.CategoryRepository.GetByName(productDto.CategoryName);
            if (category == null)
            {
                throw new ArgumentException("Category not found");
            }

            var productEntity = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Description = productDto.Description,
                ImageUrl = UploadImage(productDto.ImageFile!),
                CategoryId = category.Id,
                Count = productDto.Count,
                Rate = productDto.Rate
            };

            _unitOfWork.ProductRepository.Add(productEntity);
            _unitOfWork.SaveChanges();
            
        }


        public void DeleteProduct(int id)
        {
            var product = _unitOfWork.ProductRepository.GetById(id);
            if (product == null)
            {
                throw new ArgumentException($"Product with id {id} not found");
            }

            _unitOfWork.ProductRepository.Delete(product);
            _unitOfWork.SaveChanges();
            
        }

        public IEnumerable<ProductReadDto> GetProducts(string? categoryName, string? productName)
        {
            var products = _unitOfWork.ProductRepository.GetProducts(categoryName, productName)
                       .Select(p => new ProductReadDto
                       {
                           Id = p.Id,
                           Name = p.Name,
                           Rate = p.Rate,
                           Image = p.ImageUrl!,
                           CategoryName = _unitOfWork.CategoryRepository.GetById(p.CategoryId)?.Name ?? "Unknown",
                           Price = p.Price
                       });

            return products;
        }

        public void UpdateProduct(int id, ProductDto productDto)
        {
            var existingProduct = _unitOfWork.ProductRepository.GetById(id);
            if (existingProduct == null)
            {
                throw new ArgumentException($"Product with id {id} not found");
            }
            var category = _unitOfWork.CategoryRepository.GetByName(productDto.CategoryName);
            if (category == null)
            {
                throw new ArgumentException("Category not found");
            }

            existingProduct.Name = productDto.Name;
            existingProduct.Price = productDto.Price;
            existingProduct.Description = productDto.Description;
            existingProduct.ImageUrl = UploadImage(productDto.ImageFile!);
            existingProduct.CategoryId = category.Id;
            existingProduct.Rate = productDto.Rate;
            existingProduct.Count = productDto.Count;

            _unitOfWork.ProductRepository.Update(existingProduct);
            _unitOfWork.SaveChanges();
            
        }

        private string UploadImage(IFormFile? imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                return string.Empty;
            }
            string[] allowedExtensions = new string[] { ".jpg", ".svg", ".png" };
            var fileExtensions = Path.GetExtension(imageFile.FileName);
            if (!allowedExtensions.Contains(fileExtensions))
            {
                throw new ArgumentException("Invalid file format. Allowed formats are: .jpg, .svg, .png");
            }

            var fileName = Guid.NewGuid().ToString() + fileExtensions;

            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "images");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var filePath = Path.Combine(directoryPath, fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                imageFile.CopyTo(fileStream);
            }

            return fileName;
        }
    }
}
