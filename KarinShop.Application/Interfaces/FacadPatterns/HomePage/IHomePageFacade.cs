using KarinShop.Application.Services.HomePage.Command.AddNewHomePageImage;
using KarinShop.Application.Services.HomePage.Command.AddNewSlider;
using KarinShop.Application.Services.HomePage.Command.RemoveHomePageImage;
using KarinShop.Application.Services.HomePage.Query.GetHomePageImages;
using KarinShop.Application.Services.HomePage.Query.GetSlider;

namespace KarinShop.Application.Interfaces.FacadPatterns.HomePage
{
    public interface IHomePageFacade
    {
        public AddNewSliderServices AddNewSlider { get; }
        public IGetSlider getSlider  { get; }
        public AddNewHomePageImageServices addNewHomePageImage  { get; }
        public IGetHomePageImagesServices getHomePageImages { get; }
        public RemoveHomePageImageServices removeHomePageImage { get; }
    }
}
