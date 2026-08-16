using KarinShop.Application.Services.Common.GetMenu;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.KarinShop.ViewComponents
{
    public class GetMenu : ViewComponent
    {
        private readonly IGetMenuItem _getMenuItem;
        public GetMenu(IGetMenuItem getMenuItem)
        {
            _getMenuItem = getMenuItem;
        }
        public IViewComponentResult Invoke()
        {
            var menuItem = _getMenuItem.Execute();
            return View(viewName: "GetMenu", menuItem.Data);
        }
    }
}
