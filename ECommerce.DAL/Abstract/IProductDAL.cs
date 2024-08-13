using ECommerce.Business.Abstract;
using ECommerce.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Abstract
{
    public interface IProductDAL : IGenericRepository<Product>
    {
    }
}
