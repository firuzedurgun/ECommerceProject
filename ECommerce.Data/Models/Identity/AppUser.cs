using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Models.Identity
{
    public class AppUser : IdentityUser<int>
    {
        public AppUser() : base()
        {
        }

        public AppUser(string userName) : base(userName)
        {
        }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
