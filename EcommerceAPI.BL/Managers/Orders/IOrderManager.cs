using E_commerceAPI.BL.Dtos.Order;
using E_commerceAPI.DAL.Data.Models;
using E_commerceAPI.DAL.Repositorries.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceAPI.BL.Managers.Orders
{
    public interface IOrderManager
{
        void PlaceOrder(PlaceOrderRequestDto request);
         IEnumerable<OrderDto> GetOrderHistory();

}
}
