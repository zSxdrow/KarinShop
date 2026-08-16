using KarinShop.Domain.Entities.HomePage;
using KarinShop.Domain.Entities.Products;
using KarinShop.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
namespace KarinShop.Application.Interfaces.Context
{ 
    public interface IDataBaseContext
    {
        DbSet<User> Users { get; set; }
         DbSet<Role> Roles { get; set; }
         DbSet<UserInRole> UserInRoles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<HomePageImage> HomePageImages { get; set; }

        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
