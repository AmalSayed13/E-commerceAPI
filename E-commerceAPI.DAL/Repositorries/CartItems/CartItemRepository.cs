using E_commerceAPI.DAL.Data.Context;
using E_commerceAPI.DAL.Data.Models;
using E_commerceAPI.DAL.Repositories.CartItems;
using E_commerceAPI.DAL.Repositorries.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceAPI.DAL.Repositorries.CartItems
{
    public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(EcommerceContext context) : base(context)
        {
        }

        public IEnumerable<CartItem> GetAllByCartId(int cartId)
        {
            return _context.CartItems.Where(ci => ci.CartId == cartId).ToList();
        }
    }
}
