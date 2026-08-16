
using KarinShop.Domain.Entities.Commons;

namespace KarinShop.Domain.Entities.HomePage
{
    public class Slider : BaseEntity
    {
        public string Src { get; set; }
        public string Link { get; set; }
        public int ClickCount { get; set; }
    }
}
