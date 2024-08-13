using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Models.Identity
{
    public class AppRole : IdentityRole<int>
    {
        public AppRole() : base()
        {

        }
        public AppRole(string roleName) : base(roleName)
        {

        }
    }
}
