using E_commerceAPI.BL.Dtos.Cart;
using E_commerceAPI.BL.Managers.Carts;
using E_commerceAPI.APIs;
using E_commerceAPI.DAL.Data.Models;
using HospsitalManagement.DAL;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace E_commerceAPI.BL.Managers.Carts
{
    public class CartManager : ICartManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartManager(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }
        public CartDto GetCart()
        {
            var userId = GetUserId();
            if(userId == null)
            {
                throw new ArgumentException("please login first!");
            }
            var cart = _unitOfWork.CartRepository.GetByUserId(GetUserId());
            if (cart == null)
            {
                throw new ArgumentException("Cart not found for the user");
            }

            var cartDto = new CartDto
            {
                ID = cart.ID,
                UserId = cart.UserId,
                CartItems = _unitOfWork.CartItemRepository.GetAllByCartId(cart.ID).Select(ci => new CartItemDto
                {
                    Quantity =ci.Quantity,
                    Price =ci.Price,
                    CreatedDate = ci.CreatedDate,
                    ProductId = ci.ProductId, 
                }).ToList()
            };

            return cartDto;
        }
        public void AddToCart(int productId, int quantity)
        {
            var product = _unitOfWork.ProductRepository.GetById(productId);
            if (product == null)
            {
                throw new ArgumentException($"Product with id {productId} not found");
            }

            var cart = _unitOfWork.CartRepository.GetByUserId(GetUserId());
            if (cart == null)
            {
                cart = new Cart { UserId = GetUserId() };
                _unitOfWork.CartRepository.Add(cart);
                _unitOfWork.SaveChanges();
            }
          

            var cartItem = _unitOfWork.CartItemRepository.GetAllByCartId(cart.ID).FirstOrDefault(item => item.ProductId == productId);
            if (cartItem != null)
            {
                
                throw new ArgumentException($"this product allready exsits");
            }
           
                cart.CartItems.Add(new CartItem
                {
                    ProductId = productId,
                    Quantity = quantity,
                    Price = product.Price * quantity,
                    CreatedDate = DateTime.UtcNow
                });           

            _unitOfWork.CartRepository.Update(cart);
            _unitOfWork.SaveChanges();
        }

        public void RemoveFromCart( int productId)
        {
            var userId = GetUserId();
            if (userId == null)
            {
                throw new ArgumentException("please login first!");
            }

            var cart = _unitOfWork.CartRepository.GetByUserId(GetUserId());
            if (cart == null)
            {
                throw new ArgumentException("Cart not found for the user");
            }

            var cartItem = _unitOfWork.CartItemRepository.GetAllByCartId(cart.ID).FirstOrDefault(item => item.ProductId == productId);
            if (cartItem == null)
            {
                throw new ArgumentException($"Product with id {productId} not found in the cart");
            }

            cart.CartItems.Remove(cartItem);
            _unitOfWork.CartRepository.Update(cart);
            _unitOfWork.SaveChanges();
        }

        public void EditCartItemQuantity( int productId, int quantity)
        {
            var userId = GetUserId();
            if (userId == null)
            {
                throw new ArgumentException("please login first!");
            }
            var product = _unitOfWork.ProductRepository.GetById(productId);
            var cart = _unitOfWork.CartRepository.GetByUserId(GetUserId());
            if (cart == null)
            {
                throw new ArgumentException("Cart not found for the user");
            }

            var cartItem = _unitOfWork.CartItemRepository.GetAllByCartId(cart.ID).FirstOrDefault(item => item.ProductId == productId);
            if (cartItem == null)
            {
                throw new ArgumentException($"Product with id {productId} not found in the cart");
            }
            if(quantity <= product!.Count)
            {
                cartItem.Quantity = quantity;
            }
            else { throw new ArgumentException($"Sorry! Product with id {productId} Not available in this quantity ,the existing quantity {product.Count}"); }
            cartItem.Price = product!.Price * quantity;
            _unitOfWork.CartRepository.Update(cart);
            _unitOfWork.SaveChanges();
        }
        private string GetUserId()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
        }

        public void ClearCart()
        {
            var userId = GetUserId();
            if (userId == null)
            {
                throw new ArgumentException("please login first!");
            }

            var cart = _unitOfWork.CartRepository.GetByUserId(GetUserId());
            if (cart == null)
            {
                throw new ArgumentException("Cart not found for the user");
            }
            _unitOfWork.CartRepository.Delete(cart);
            _unitOfWork.SaveChanges();

        }
    }
}

