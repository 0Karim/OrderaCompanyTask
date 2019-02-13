using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrderaTaskVersion2.Models;
using OrderaTaskVersion2.DAL.RepositoryInterfaces;

namespace OrderaTaskVersion2.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProductContext context = new ProductContext();
        private Repository<ProductCategories> categoryRepository;
        private ProductRepository productRepository;


        public UnitOfWork(ProductContext _context)
        {
            context = _context;
            
        }

        public Repository<ProductCategories> CategoreyRepository
        {
            get
            {
                if (this.categoryRepository == null)
                    this.categoryRepository = new Repository<ProductCategories>(context);
                return categoryRepository;
            }
        }

        public ProductRepository _ProductRepository
        {
            get
            {
                if (this.productRepository == null)
                    this.productRepository = new ProductRepository(context);
                return productRepository;
            }
        }

        public ProductRepository Product
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public CategoryRepository Category
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        private bool dispose = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.dispose)
                if (disposing)
                    context.Dispose();
            this.dispose = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}