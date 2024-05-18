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

        public void PlaceOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            _context.Orders.Add(order);
            _context.SaveChanges();
        }



        public IEnumerable<Order> GetOrderHistory()
        {
            return _context.Orders;
        }
    }
}
