using ECommerce.Business.Concreate;
using ECommerce.DAL.Abstract;
using ECommerce.Data.Context;
using ECommerce.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Concreate
{
    public class ProductDAL : GenericRepository<Product,ECommerceContext>, IProductDAL
    {
    }
}
