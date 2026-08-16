using KarinShop.Application.Services.HomePage.Query.GetHomePageImages;
using KarinShop.Application.Services.HomePage.Query.GetSlider;
using KarinShop.Application.Services.Products.Queries.GetProductListForSite;

namespace EndPoint.KarinShop.Models.ViewModels.HomePageViewModel
{
    public class HomePageViewModel
    {
        public List<GetSliderDto> Sliders { get; set; }
        public List<GetProductListForSiteDto> Products { get; set; }
        public List<HomePageImageDto> HomePageImages { get; set; }
    }
}
