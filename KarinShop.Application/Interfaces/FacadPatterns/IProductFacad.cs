using KarinShop.Application.Services.Products.Commands.AddCategory;
using KarinShop.Application.Services.Products.Commands.AddFeature;
using KarinShop.Application.Services.Products.Commands.AddProduct;
using KarinShop.Application.Services.Products.Commands.AddProductImage;
using KarinShop.Application.Services.Products.Commands.EditCategory;
using KarinShop.Application.Services.Products.Commands.EditProduct;
using KarinShop.Application.Services.Products.Commands.EditProductFeature;
using KarinShop.Application.Services.Products.Commands.ProductDisplayChange;
using KarinShop.Application.Services.Products.Commands.RemoveCategory;
using KarinShop.Application.Services.Products.Commands.RemoveProduct;
using KarinShop.Application.Services.Products.Commands.RemoveProductFeature;
using KarinShop.Application.Services.Products.Commands.RemoveProductImage;
using KarinShop.Application.Services.Products.Queries.GetAllCategories;
using KarinShop.Application.Services.Products.Queries.GetCategory;
using KarinShop.Application.Services.Products.Queries.GetProductDetailForSite;
using KarinShop.Application.Services.Products.Queries.GetProductForAdmin;
using KarinShop.Application.Services.Products.Queries.GetProductListForSite;
using KarinShop.Application.Services.Products.Queries.ProductDetailForAdmin;

namespace KarinShop.Application.Interfaces.FacadPatterns
{
    public interface IProductFacad
    {
        public IGetCategories GetCategoriesServices { get; }
        public AddNewCategoryServices AddCategoriesServices { get; }
        public CategoryRemoveServices CategoryRemoveServices { get; }
        public EditCategoryServices editCategoryServices { get; }
        public IGetAllCategories getAllCategories { get; }

        //Product

        public AddNewProductServices addProduct { get; }
        public IGetProductForAdmin getProductAdmin { get; }
        public IGetProductDetailForAdmin getProductDetailAdmin { get; }
        public RemoveProductService removeProduct { get; }
        public EditProductServices editProduct { get; }
        public EditProductFeatureServices editProductFeature { get; }
        public ProductDisplayChangeServices changeProductDisplay { get; }

        //site

        public IGetProductListForSite getProductLIstForSite { get; }
        public IGetProductDetailForSite getProductDetailForSite { get; }

        public RemoveProductFeatureServices RemoveProductFeature { get; }
        public AddNewProductFeatureServices addNewProductFeatureServices { get; }
        public RemoveProductImageServices removeProductImage { get; }
    }
}
