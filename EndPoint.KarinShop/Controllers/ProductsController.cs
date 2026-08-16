using KarinShop.Application.Interfaces.FacadPatterns;
using KarinShop.Application.Services.Products.Queries.GetProductListForSite;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.KarinShop.Controllers
{
    public class ProductsController : Controller
    {
        private IProductFacad _productFacade;
        public ProductsController(IProductFacad productFacad)
        {
            _productFacade = productFacad;
        }
        public IActionResult Index(Ordering ordering, string SearchKey, int Page = 1, int PageSize = 20, long? CatID = null)
        {
            return View(_productFacade.getProductLIstForSite.Execute(ordering, SearchKey, Page, PageSize, CatID).Data);
        }
        [HttpGet]
        public IActionResult Detail(long ID)
        {
            var result = _productFacade.getProductDetailForSite.Execute(ID).Data;
            return View(result);
        }
    }
}
