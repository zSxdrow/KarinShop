using KarinShop.Application.Interfaces.Context;
using KarinShop.Common.Classes;
using KarinShop.Domain.Entities.HomePage;
using KarinShop.Domain.Entities.Products;
using KarinShop.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarinShop.Persistence.Context
{
    public class DataBaseContext : DbContext , IDataBaseContext
    {

        public DataBaseContext(DbContextOptions<DataBaseContext> options) :base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<HomePageImage> HomePageImages { get; set; }

        



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //add ROles
            modelBuilder.Entity<Role>().HasData(new Role { RoleID = 1, RoleName = nameof(UserRoles.Admin) });
            modelBuilder.Entity<Role>().HasData(new Role { RoleID = 2, RoleName = nameof(UserRoles.Operator) });
            modelBuilder.Entity<Role>().HasData(new Role { RoleID = 3, RoleName = nameof(UserRoles.Customer) });
            modelBuilder.Entity<Role>().HasData(new Role { RoleID = 4, RoleName = nameof(UserRoles.Staff) });


            //is removed role
            modelBuilder.Entity<Role>().Property(x => x.InsertTime)
            .HasDefaultValueSql("GETDATE()");


            //yekta boodn UserName
            modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();

            //filter kardan user haye delete shode
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Role>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<UserInRole>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Category>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<ProductImage>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<ProductFeature>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<HomePageImage>().HasQueryFilter(p => !p.IsRemoved);
        }
    }
}
