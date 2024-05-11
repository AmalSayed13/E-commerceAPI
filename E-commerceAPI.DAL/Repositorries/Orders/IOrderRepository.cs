using E_commerceAPI.DAL.Data.Models;
using E_commerceAPI.DAL.Repositorries.Generic;
using System.Collections.Generic;

namespace E_commerceAPI.DAL.Repositories.Orders
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        void PlaceOrder(List<OrderItem> orderItems);
        IEnumerable<Order> GetOrderHistory();
    }
}
