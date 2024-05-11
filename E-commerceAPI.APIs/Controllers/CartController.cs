using E_commerceAPI.BL.Dtos.Cart;
using E_commerceAPI.BL.Managers.CartItems;
using E_commerceAPI.BL.Managers.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace E_commerceAPI.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartManager _cartManager;
        private readonly IProductManager _productManager;

        public CartController(ICartManager cartManager , IProductManager productManager)
        {
            _cartManager = cartManager;
            _productManager = productManager;
        }
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<CartItemReadDto>> GetAll()
        {
            try
            {
                var cartItems = _cartManager.GetALL();
                return Ok(cartItems);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving cart items: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("{productId}/{Quantity}")]
        public IActionResult AddToCart(int productId, int Quantity)
        {
            try
            {
                var product = _productManager.GetById(productId);
                if (product != null)
                {
                    var item = _cartManager.GetByProductId(productId);
                    if (item != null)
                    {
                        _cartManager.AddToCart(productId, Quantity);
                        return Ok($"Done! Added product with ID {productId} to the cart.");
                    }
                    else
                    {
                        return NotFound($"Sorry!!Product with ID {productId} already exists in the cart.");
                    }
                }
                else
                {
                    return NotFound($"Sorry!!Product with ID {productId} Not Found in Products");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the product to the cart: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("{productId}")]
        public IActionResult RemoveFromCart(int productId)
        {
            try
            {
                
                    var item = _cartManager.GetByProductId(productId);
                    if (item != null)
                    {
                        _cartManager.RemoveFromCart(productId);
                        return Ok($"Done! Removed product with ID {productId} from the cart.");
                    }
                    else
                    {
                        return NotFound($"Sorry!!Product with ID {productId} was not found in the cart.");
                    }
                }
               
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while removing the product from the cart: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("{productId}/{Quantity}")]
        public IActionResult EditCartItemQuantity(int productId, int Quantity)
        {
            try
            {
                var product = _productManager.GetById(productId);
                if (product != null)
                {
                    var item = _cartManager.GetByProductId(productId);
                if (item != null)
                {
                    _cartManager.EditCartItemQuantity(productId, Quantity);
                    return Ok($"Done! Edited quantity of product with ID {productId}.");
                }
                else
                {
                    return NotFound($"Sorry!! Product with ID {productId} was not found in the cart.");
                }
            }
                 else
                {
                    return NotFound($"Sorry!!Product with ID {productId} Not Found in Products");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while editing the quantity of the product in the cart: {ex.Message}");
            }
        }
    }
}
