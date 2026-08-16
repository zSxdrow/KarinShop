using KarinShop.Domain.Entities.Commons;

namespace KarinShop.Domain.Entities.HomePage
{
    public class HomePageImage : BaseEntity
    {
        public string Src { get; set; }
        public string Link { get; set; }
        public ImageLocation Location { get; set; }
        public string? Title { get; set; }

    }
    public enum ImageLocation
    {
        Center1 = 0,
        Center2 = 1,
        Categories = 2,
        Brands = 3,

    }
}
