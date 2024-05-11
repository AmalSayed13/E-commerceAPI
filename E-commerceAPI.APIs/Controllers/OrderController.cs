using E_commerceAPI.BL.Managers.Products;
using Microsoft.AspNetCore.Mvc;

namespace E_commerceAPI.APIs.Controllers
{
    public class OrderController : Controller
    {
        private readonly IProductManager _productManager;

        public OrderController(IProductManager productManager)
        {
            _productManager = productManager;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
