using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceAPI.DAL.Data.Models
{
    public class Order
    {
        public int ID { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedDateTime { get; set; }

        //order has many of order items
        public ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();

        //user can make order 
        public string UserId { get; set; } = string.Empty;
        public User? User { get; set; }
}
}
