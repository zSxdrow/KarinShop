using EndPoint.KarinShop.Models;
using EndPoint.KarinShop.Models.ViewModels.HomePageViewModel;
using KarinShop.Application.Interfaces.FacadPatterns;
using KarinShop.Application.Interfaces.FacadPatterns.HomePage;
using KarinShop.Application.Services.Products.Queries.GetProductListForSite;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EndPoint.KarinShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomePageFacade _homePageFacade;
        private readonly IProductFacad _productFacad;
        public HomeController(IProductFacad productFacad , IHomePageFacade homePageFacade)
        {
            _homePageFacade = homePageFacade;
            _productFacad = productFacad;
        }
        public IActionResult Index(Ordering ordering, string SearchKey, int Page = 1,int PageSize = 20, long? CatID = null)
        {
            HomePageViewModel homePage = new()
            {
                Products = _productFacad.getProductLIstForSite.Execute(ordering, SearchKey, Page, PageSize, CatID).Data.Product,
                Sliders = _homePageFacade.getSlider.Execute().Data,
                HomePageImages = _homePageFacade.getHomePageImages.Execute().Data,
            };
            return View(homePage);
        }
        public IActionResult Privacy()
        {
            return View();
        }

     
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult ContactUS()
        {
            return View();
        }
        public IActionResult WebLog()
        {
            return View();
        }



    }
}
