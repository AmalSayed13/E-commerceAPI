using E_commerceAPI.DAL.Data.Context;
using E_commerceAPI.DAL.Data.Models;
using E_commerceAPI.DAL.Repositorries.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace E_commerceAPI.DAL.Repositories.Orders
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(EcommerceContext context) : base(context)
        {
        }

        public void PlaceOrder(List<OrderItem> orderItems)
        {
            decimal totalPrice = 0;
            foreach (var orderItem in orderItems)
            {
                var product = _context.Products.Find(orderItem.ProductId);
                if (product != null)
                {
                    totalPrice += product.Price * orderItem.Quantity;
                }
            }

            var order = new Order
            {
                TotalPrice = totalPrice,
                CreatedDateTime = DateTime.Now,
                OrderItems = orderItems
            };

            _context.Orders.Add(order);
        }

        public IEnumerable<Order> GetOrderHistory()
        {
            return _context.Orders;
        }
    }
}
