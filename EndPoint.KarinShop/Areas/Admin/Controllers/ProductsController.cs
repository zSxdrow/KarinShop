using AspNetCoreGeneratedDocument;
using KarinShop.Application.Interfaces.FacadPatterns;
using KarinShop.Application.Services.Products.Commands.AddFeature;
using KarinShop.Application.Services.Products.Commands.AddProduct;
using KarinShop.Application.Services.Products.Commands.AddProductImage;
using KarinShop.Application.Services.Products.Commands.EditCategory;
using KarinShop.Application.Services.Products.Commands.EditProduct;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using static KarinShop.Application.Services.Products.Queries.ProductDetailForAdmin.GetProductDetailForAdminServices;

namespace EndPoint.KarinShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductFacad _productFacad;
        private readonly IAddProductImage _addProductImage;
        public ProductsController(IProductFacad productFacad , IAddProductImage addProductImage )
        {
            _productFacad = productFacad;
            _addProductImage = addProductImage;
        }
        [HttpGet]
        public IActionResult Index(int Page = 1, int PageSize = 20)
        {
            return View(_productFacad.getProductAdmin.Execute().Data);
        }

        [HttpPost]
        [HttpGet]
        public IActionResult Detail(long ID)
        {
            var result = _productFacad.getProductDetailAdmin.Execute(ID).Data;
            return View(result);
        }

        public IActionResult Category(int? ParentID)
        {
            return View(_productFacad.GetCategoriesServices.Execute(ParentID).Data);
        }
        [HttpGet]
        public IActionResult AddNewCategory(int? ParentID)
        {
            ViewBag.ParentID = ParentID;
            return View();
        }
        [HttpPost]
        public IActionResult AddNewCategory(int? ParentID, string Name)
        {
            var result = _productFacad.AddCategoriesServices.Execute(ParentID, Name);
            return Json(result);
        }
        [HttpPost]
        public IActionResult RemoveCategory(int CategoryID)
        {
            return Json(_productFacad.CategoryRemoveServices.Execute(CategoryID));
        }
        [HttpPost]
        public IActionResult EditCategory(int CategoryID, string Name)
        {
            return Json(_productFacad.editCategoryServices.Execute(new RequestEditCategory { CategoryID = CategoryID, Name = Name }));
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            ViewBag.Categories = new SelectList(_productFacad.getAllCategories.Execute().Data, "ID", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(RequestAddProduct request, List<AddNewProduct_Feature> Feature)
        {
            List<IFormFile> images = new List<IFormFile>();
            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                var file = Request.Form.Files[i];
                images.Add(file);
            }
            request.Images = images;
            return Json(_productFacad.addProduct.Execute(request));
        }

        [HttpPost]
        public IActionResult RemoveProduct(long ID)
        {
            var result = _productFacad.removeProduct.Execute(ID);
            return Json(result);
        }
        [HttpGet]
        public IActionResult Edit(long ID)
        {
            var result = _productFacad.getProductDetailAdmin.Execute(ID).Data;
            ViewBag.Categories = new SelectList(_productFacad.getAllCategories.Execute().Data, "ID", "Name", result.CategoryID);
            ViewBag.ID = ID;
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(long ID, string Name, string Description, string Brand, int Price, int CategoryID, int Inventory, bool Displayed)
        {
            var result = _productFacad.editProduct.Execute(new RequestEditProduct
            {
                ID = ID,
                Name = Name,
                Description = Description,
                Brand = Brand,
                Price = Price,
                CategoryID = CategoryID,
                Inventory = Inventory,
                Displayed = Displayed
            });

            return Json(result);
        }
        [HttpPost]
        public IActionResult DisplayChange(long ID)
        {
            return Json(_productFacad.changeProductDisplay.Execute(ID));
        }
        [HttpPost]
        public IActionResult RemoveFeature(int ID)
        {
            return Json(_productFacad.RemoveProductFeature.Execute(ID));
        }
        [HttpPost]
        public IActionResult AddNewFeature(int ProductID, string DisplayName, string Value)
        {
            var result = _productFacad.addNewProductFeatureServices.Execute(new List<AddNewProductFeatureDto>
            {
                new AddNewProductFeatureDto
                {
                    ProductID = ProductID,
                    DisplayName = DisplayName,
                    Value = Value
                }
            });
            return Json(result);
        }
        [HttpPost]
        public IActionResult RemoveImage(long ImageID)
        {
            var result = _productFacad.removeProductImage.Execute(ImageID);
            return Json(result);
        }
        [HttpPost]
        public IActionResult AddProductImage(List<IFormFile> file , int ProductID , string FolerName = "Products" )
        {
            var result = _addProductImage.Execute(new RequestAddProductImage
            {
                FolderName = FolerName,
                ProductID = ProductID,
                Images = file
            });
            return Json(result);
        }

    }
}
