using OrderaTaskVersion2.DAL;
using OrderaTaskVersion2.DAL.RepositoryInterfaces;
using OrderaTaskVersion2.Models;

namespace OrderaTaskVersion2
{
    public class CategoryRepository : Repository<ProductCategories> , ICategoryRepository
    {
        public CategoryRepository(ProductContext context)
            :base(context)
        {

        }
    }
}