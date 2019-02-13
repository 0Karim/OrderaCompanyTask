using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using OrderaTaskVersion2.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OrderaTaskVersion2.DAL
{
    public class ProductContext : DbContext 
    {
        
        public ProductContext() 
            :base("Name=DefaultConnection")
        {

        }

        public static ProductContext Create()
        {
            return new ProductContext();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategories> Categories { get; set; }

        public DbSet<ApplicationUser> identity { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin>().HasKey(user => user.UserId);
            modelBuilder.Entity<IdentityUserRole>().HasKey(userrole => userrole.RoleId);
            modelBuilder.Entity<IdentityRole>().HasKey(role => role.Id);
        }
    }
}