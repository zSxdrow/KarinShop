using KarinShop.Application.Services.Common.GetCategory;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.KarinShop.ViewComponents
{
    public class Search : ViewComponent
    {
        private readonly IGetCategory _getCategory;
        public Search(IGetCategory getCategory)
        {
            _getCategory = getCategory;
        }
        public IViewComponentResult Invoke()
        {
            return View(viewName:"Search" , _getCategory.Execute().Data);
        }
    }
}
