using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceAPI.BL.Dtos.Cart
{
    public class CartItemReadDto
{
        public int ID { get; set; }
        public int Quantity { get; set; }
        public int ProductID { get; set; }
        public decimal Price { get; set; }
    }
}
