using KarinShop.Domain.Entities.Commons;
using Microsoft.Build.Graph;

namespace KarinShop.Domain.Entities.Products
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool Displayed { get; set; }

        public virtual Category Category { get; set; }
        public int CategoryID { get; set; }
        public virtual ICollection<ProductImage> ProductImage { get; set; }
        public virtual ICollection<ProductFeature> ProductFeature { get; set; }

        public int ViewCount { get; set; }
    }
}
