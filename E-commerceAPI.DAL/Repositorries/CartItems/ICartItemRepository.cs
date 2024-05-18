using E_commerceAPI.DAL.Repositorries.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceAPI.DAL.Repositorries.CartItems
{
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
        public IEnumerable<CartItem> GetAllByCartId(int cartId);
    }
}
