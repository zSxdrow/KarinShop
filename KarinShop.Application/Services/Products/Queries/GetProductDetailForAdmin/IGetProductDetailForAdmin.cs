using KarinShop.Application.Interfaces.Context;
using KarinShop.Common.Dto;
using KarinShop.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using static KarinShop.Application.Services.Products.Queries.ProductDetailForAdmin.GetProductDetailForAdminServices;

namespace KarinShop.Application.Services.Products.Queries.ProductDetailForAdmin
{
    public interface IGetProductDetailForAdmin
    {
        ResultDto<ProductDetailForAdminDto> Execute(long ID);
    }
    public class GetProductDetailForAdminServices : IGetProductDetailForAdmin
    {
        private readonly IDataBaseContext _context;
        public GetProductDetailForAdminServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ProductDetailForAdminDto> Execute(long ID)
        {
            var product = _context.Products
                .Include(p => p.Category)
                .ThenInclude(p => p.ParentCategory)
                .Include(p => p.ProductFeature)
                .Include(p => p.ProductImage)
                .Where(p => p.ID == ID)
                .FirstOrDefault();
            return new ResultDto<ProductDetailForAdminDto>
            {
                Data = new ProductDetailForAdminDto
                {

                    Name = product.Name,
                    Brand = product.Brand,
                    Description = product.Description,
                    Inventory = product.Inventory,
                    Category = $"{product.Category.ParentCategory?.CategoryName} - {product.Category.CategoryName}",
                    Displayed = product.Displayed,
                    Price = product.Price,
                    CategoryID = product.CategoryID,

                    Features = product.ProductFeature.ToList().Select(p => new ProductDetailFeatureDto
                    {
                        ID = p.ID,
                        DisplayName = p.DisplayName,
                        Value = p.Value,
                    }).ToList(),

                    Images = product.ProductImage.ToList().Select(p => new ProductDetailImagesDto
                    {
                        ID = p.ID,
                        Src = p.Src,
                    }).ToList()
                }
            };
        }
    
        public class ProductDetailForAdminDto
        {
            public long ID { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public long CategoryID { get; set; }
            public string Brand { get; set; }
            public string Description { get; set; }
            public int Price { get; set; }
            public int Inventory { get; set; }
            public bool Displayed { get; set; }
            public List<ProductDetailFeatureDto> Features { get; set; }
            public List<ProductDetailImagesDto> Images { get; set; }

        }

        public class ProductDetailImagesDto
        {
            public long ID { get; set; }
            public string Src { get; set; }
        }

        public class ProductDetailFeatureDto
        {
            public long ID { get; set; }
            public string DisplayName { get; set; }
            public string Value { get; set; }
        }
    }
}
