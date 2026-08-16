using KarinShop.Application.Interfaces.Context;
using KarinShop.Application.Interfaces.FacadPatterns;
using KarinShop.Application.Services.Common.UploadFile;
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
using KarinShop.Application.Services.Products.Queries.GetChildCategories;
using KarinShop.Application.Services.Products.Queries.GetProductDetailForSite;
using KarinShop.Application.Services.Products.Queries.GetProductForAdmin;
using KarinShop.Application.Services.Products.Queries.GetProductListForSite;
using KarinShop.Application.Services.Products.Queries.ProductDetailForAdmin;
using Microsoft.AspNetCore.Hosting;

namespace KarinShop.Application.Services.Products.FacadPattern
{
    //baraye command ha az class services baraye query ha az interface
    public class ProductFacade : IProductFacad
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _Environment;
        private readonly IGetChildCategories _getChildCategories;
        public ProductFacade(IDataBaseContext context, IHostingEnvironment environment , IGetChildCategories getChildCategories )
        {
            _getChildCategories = getChildCategories;
            _context = context;
            _Environment = environment;
        }


        private IGetCategories _getCategories;
        public IGetCategories GetCategoriesServices
        {
            get
            {

                return _getCategories = _getCategories ?? new GetCategoryServices(_context);
            }
        }


        private AddNewCategoryServices _addNewCategory;
        AddNewCategoryServices IProductFacad.AddCategoriesServices

        {
            get
            {
                return _addNewCategory = _addNewCategory ?? new AddNewCategoryServices(_context);
            }
        }
        private CategoryRemoveServices _removeCategory;
        CategoryRemoveServices IProductFacad.CategoryRemoveServices
        {
            get
            {
                return _removeCategory = _removeCategory ?? new CategoryRemoveServices(_context);
            }
        }
        private EditCategoryServices _editCategory;
        EditCategoryServices IProductFacad.editCategoryServices
        {
            get
            {
                return _editCategory = _editCategory ?? new EditCategoryServices(_context);
            }
        }
        private AddNewProductServices _addProduct;
        AddNewProductServices IProductFacad.addProduct
        {
            get
            {
                return _addProduct = _addProduct ?? new AddNewProductServices(_context, _Environment);
            }
        }

        private IGetAllCategories _getAllCategories;
        public IGetAllCategories getAllCategories
        {
            get
            {
                return _getAllCategories = _getAllCategories ?? new GetAllCategoriesServices(_context);
            }
        }

        private IGetProductForAdmin _getProductForAdmin;
        public IGetProductForAdmin getProductAdmin
        {
            get
            {
                return _getProductForAdmin = _getProductForAdmin ?? new GetPRoductForAdminServices(_context);
            }
        }


        private IGetProductDetailForAdmin _getProductDetailForAdmin;
        public IGetProductDetailForAdmin getProductDetailAdmin
        {
            get
            {
                return _getProductDetailForAdmin = _getProductDetailForAdmin ?? new GetProductDetailForAdminServices(_context);
            }
        }
        private RemoveProductService _removeProduct;
        public RemoveProductService removeProduct
        {
            get
            {
                return _removeProduct = _removeProduct ?? new RemoveProductService(_context);
            }
        }

        private EditProductServices _editProduct;
        public EditProductServices editProduct
        {
            get
            {
                return _editProduct = _editProduct ?? new EditProductServices(_context);
            }
        }

        private EditProductFeatureServices _editProductFeature;
        public EditProductFeatureServices editProductFeature
        {
            get
            {
                return _editProductFeature = _editProductFeature ?? new EditProductFeatureServices(_context);
            }
        }

        private ProductDisplayChangeServices _productDisplayChange;
        public ProductDisplayChangeServices changeProductDisplay
        {
            get
            {
                return _productDisplayChange = _productDisplayChange ?? new ProductDisplayChangeServices(_context);
            }
        }
        private IGetProductListForSite _getProductListForSite;
        public IGetProductListForSite getProductLIstForSite
        {
            get
            {
                return _getProductListForSite = _getProductListForSite ?? new GetProductListForSiteServices(_context , _getChildCategories);
            }
        }
        private IGetProductDetailForSite _getProductDetailForSite;
        public IGetProductDetailForSite getProductDetailForSite
        {
            get
            {
                return _getProductDetailForSite = _getProductDetailForSite ?? new GetProductDetailForSiteServices(_context);
            }
        }

        private RemoveProductFeatureServices _removeProductFeatureServices;
        public RemoveProductFeatureServices RemoveProductFeature
        {
            get
            {
                return _removeProductFeatureServices = _removeProductFeatureServices ?? new RemoveProductFeatureServices(_context);
            }
        }
        private AddNewProductFeatureServices _addNewProductFeatureServices;
        public AddNewProductFeatureServices addNewProductFeatureServices
        {
            get
            {
                return _addNewProductFeatureServices = _addNewProductFeatureServices ?? new AddNewProductFeatureServices(_context);
            }
        }
        private RemoveProductImageServices _removeProductImage;
        public RemoveProductImageServices removeProductImage
        {
            get
            {
                return _removeProductImage = _removeProductImage ?? new RemoveProductImageServices(_context);
            }
        }
     
    }
}