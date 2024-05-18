using E_commerceAPI.DAL.Data.Models;
using E_commerceAPI.DAL.Repositorries.Generic;
using System.Collections.Generic;

namespace E_commerceAPI.DAL.Repositories.Orders
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        public void PlaceOrder(Order order);
        IEnumerable<Order> GetOrderHistory();
    }
}
