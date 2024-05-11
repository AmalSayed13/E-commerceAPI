using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceAPI.BL.Dtos.Product
{
    public class ProductDetailsDto
{
    public string? ImageFile { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Rate { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public int Count { get; set; }
}
}
