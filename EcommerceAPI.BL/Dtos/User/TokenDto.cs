using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceAPI.BL.Dtos.User
{
    public record class TokenDto(string Token , DateTime Expiry);
}
