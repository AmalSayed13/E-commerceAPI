using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceAPI.DAL.Data.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public decimal PriceTotal { get; set;}
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }

        //order item has only one order
        public int OrderId { get; set; }
        public Order? Order { get; set; }

        //each one of order has one product
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        
    }
}
