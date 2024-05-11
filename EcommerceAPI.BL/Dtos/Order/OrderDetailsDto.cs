using E_commerceAPI.BL.Dtos.Cart;
using E_commerceAPI.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceAPI.BL.Dtos.Order
{
    public class OrderDetailsDto
{
       public int Id { get; set; }
        public IEnumerable<CartItemReadDto> cartItems { get; set; } = [];
    }
}
