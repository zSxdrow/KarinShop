using KarinShop.Application.Interfaces.FacadPatterns.HomePage;
using KarinShop.Domain.Entities.HomePage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace EndPoint.KarinShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomePageController : Controller
    {
        private IHomePageFacade _homePageFacade;
        public HomePageController(IHomePageFacade homePageFacade)
        {
            _homePageFacade = homePageFacade;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult AddNewSlider()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewSlider(IFormFile File , string Link)
        {
           var result =  _homePageFacade.AddNewSlider.Execute(File, Link);
            TempData["IsSuccess"] = result.IsSuccess;
            TempData["Message"] = result.Message;
            return RedirectToAction("AddNewSlider");
        }
        [HttpGet]
        public IActionResult AddNewHomePageImage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewHomePageImage(IFormFile file , string Link , ImageLocation location , string Title)
        {
            
            var result = _homePageFacade.addNewHomePageImage.Execute(new RequestAddNewHomePageImage
            {
                file = file,
                Link = Link,    
                Location = location,
                Title = Title
                
            });
            return Json(result);
        }
        [HttpGet]
        public IActionResult RemoveHomePageImage()
        {
           return View(_homePageFacade.getHomePageImages.Execute().Data);
        }
        [HttpPost]
        public IActionResult RemoveHomePageImage(long ID)
        {
            var result = _homePageFacade.removeHomePageImage.Execute(ID);
            return Json(result);
        }
    }
}
