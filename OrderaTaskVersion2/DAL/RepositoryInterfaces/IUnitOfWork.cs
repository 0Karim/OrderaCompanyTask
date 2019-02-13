using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderaTaskVersion2.DAL.RepositoryInterfaces
{
    interface IUnitOfWork : IDisposable
    {
        ProductRepository Product { get; }
        CategoryRepository Category { get; }
    }
}
