using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using E_commerceAPI.DAL.Data.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace E_commerceAPI.DAL.Data.Models
{
    public class User : IdentityUser
    {
        public int Age { get; set; }
        public string Address { get; set; }= string.Empty;
        public Gender Gender { get; set; }

        public string UserRole { get; set; } = "User";
        //User can make many orders
        public ICollection<Order> Orders { get; set; } = [];

        //User Has One Cart in website
        public int CartID { get; set; }
        public Cart? Cart { get; set; }
    }
}
