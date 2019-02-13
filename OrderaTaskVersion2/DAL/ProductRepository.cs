using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OrderaTaskVersion2.DAL.RepositoryInterfaces;
using OrderaTaskVersion2.Models;

namespace OrderaTaskVersion2.DAL
{
    public class ProductRepository : Repository<Product> , IProductRepository  
    {
        public ProductRepository(ProductContext context) : base(context)
        {

        }

        IEnumerable<ProductCategories> IProductRepository.GetAllCategories()
        {
            return ProductContext.Create().Categories.ToList();
        }
        

        ProductCategories IProductRepository.GetSelectedCategoryWithProduct(int categoryID)
        {
            return ProductContext.Create().Categories.SingleOrDefault(c => c.ID == categoryID);
        }

    }
}