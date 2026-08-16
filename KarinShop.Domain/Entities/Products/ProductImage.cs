using KarinShop.Domain.Entities.Commons;

namespace KarinShop.Domain.Entities.Products
{
    public class ProductImage : BaseEntity
    {
        public virtual Product Product { get; set; }
        public int ProductID { get; set; }
        public string Src { get; set; }
    }
}
