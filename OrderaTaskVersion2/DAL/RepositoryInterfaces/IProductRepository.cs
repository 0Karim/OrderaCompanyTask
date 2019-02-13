using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderaTaskVersion2.Models;

namespace OrderaTaskVersion2.DAL.RepositoryInterfaces
{
    public interface IProductRepository : IRepository<Product>
    {
         IEnumerable<ProductCategories> GetAllCategories();
         ProductCategories GetSelectedCategoryWithProduct(int categoryID);
    }
}
