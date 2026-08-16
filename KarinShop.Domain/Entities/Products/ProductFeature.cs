using KarinShop.Domain.Entities.Commons;

namespace KarinShop.Domain.Entities.Products
{
    public class ProductFeature : BaseEntity
    {
        public virtual Product Product { get; set; }
        public int ProductID { get; set; }
        public string DisplayName { get; set; }
        public string Value { get; set; }


    }
}
