using Microsoft.AspNetCore.Http;


namespace Dtos.Product
{
    public class ProductDto
{
        public IFormFile ImageFile { get; set; } = null!;
        public string Name { get; set; } = string.Empty;
        public int Rate { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Count { get; set; }
    }
}
