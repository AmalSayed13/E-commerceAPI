using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceAPI.BL.Dtos.Order
{
    public class OrderDto
    {
        public int ID { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}