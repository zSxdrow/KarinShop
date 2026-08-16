using KarinShop.Application.Interfaces.Context;
using KarinShop.Common.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace KarinShop.Application.Services.Products.Queries.GetProductDetailForSite
{
    public interface IGetProductDetailForSite
    {
        ResultDto<ProductDetailForSite_Dto> Execute(long ID);
    }

    public class GetProductDetailForSiteServices : IGetProductDetailForSite
    {
        private readonly IDataBaseContext _context;
        public GetProductDetailForSiteServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ProductDetailForSite_Dto> Execute(long ID)
        {
          var product = _context.Products
                .Include(p => p.Category)
                .ThenInclude(p => p.ParentCategory)
                .Include(p=> p.ProductImage)
                .Include(p => p.ProductFeature)
                .FirstOrDefault(p => p.ID == ID);
            if(product == null)
            {
                throw new Exception("محصول یافت نشد!");
            }

            product.ViewCount++;
            _context.SaveChanges();
            return new ResultDto<ProductDetailForSite_Dto>
            {
                Data = new ProductDetailForSite_Dto
                {
                    ID = product.ID,
                    Name = product.Name,
                    Brand = product.Brand,
                    Category = $"{product.Category.ParentCategory?.CategoryName} - {product.Category.CategoryName}",
                    Description = product.Description,
                    Inventory = product.Inventory,
                    Price = product.Price,
                    Images = product.ProductImage.Select(p => p.Src).ToList(),
                    Features = product.ProductFeature.Select(p => new ProductDetailForSite_FeatureDto 
                    { 
                        DisplayName = p.DisplayName, Value = p.Value })
                    .ToList()
                },
                IsSuccess = true
            };
        }
    }

    public class ProductDetailForSite_Dto
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public int ViewCount { get; set; }
        public List<string> Images { get; set; }
        public List<ProductDetailForSite_FeatureDto> Features {  get; set; }

    }

    public class ProductDetailForSite_FeatureDto
    {
        public string DisplayName { get; set; }
        public string Value { get; set; }
    }
}
