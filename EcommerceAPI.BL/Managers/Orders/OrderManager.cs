using System.Security.Claims;
using E_commerceAPI.BL.Dtos.Order;
using E_commerceAPI.DAL.Data.Models;
using HospsitalManagement.DAL;
using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.BL.Managers.Orders
{
    public class OrderManager : IOrderManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderManager(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public void PlaceOrder(PlaceOrderRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            string userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                throw new InvalidOperationException("PLease login first!!");
            }

            var orderItems = new List<OrderItem>();

            foreach (var item in request.OrderItems!)
            {
                var product = _unitOfWork.ProductRepository.GetById(item.ProductId);
                if (product == null)
                {
                    throw new ArgumentException($"Product with ID {item.ProductId} not found.");
                }

                if (product.Count < item.Quantity)
                {
                    throw new InvalidOperationException($"Quantity of product {product.Name} is insufficient, please enter quantity of range {product.Count}");
                }

                orderItems.Add(new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    CreatedDate = DateTime.UtcNow,
                    PriceTotal = product.Price * item.Quantity
                });
                product.Count -= item.Quantity;
            }

            var order = new Order
            {
                UserId = userId,
                TotalPrice = CalculateTotalPrice(orderItems),
                CreatedDateTime = DateTime.UtcNow,
                OrderItems = orderItems
            };
            
            _unitOfWork.OrderRepository.PlaceOrder(order);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<OrderDto> GetOrderHistory()
        {
            string userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                throw new InvalidOperationException("Please login first!!!");
            }

            var orderHistory = _unitOfWork.OrderRepository.GetOrderHistory()
                .Where(o => o.UserId == userId)
                .Select(o => new OrderDto
                {
                    ID = o.ID,
                    TotalPrice = o.TotalPrice,
                    CreatedDateTime = o.CreatedDateTime
                })
                .ToList();

            return orderHistory;
        }

        private string GetUserId()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
        }


    private decimal CalculateTotalPrice(List<OrderItem> orderItems)
        {
            decimal totalPrice = 0;
            foreach (var orderItem in orderItems)
            {
                totalPrice += orderItem.PriceTotal;
            }
            return totalPrice;
        }
    }
}
