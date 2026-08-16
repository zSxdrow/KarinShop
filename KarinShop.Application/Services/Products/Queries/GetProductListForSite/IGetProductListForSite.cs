using KarinShop.Application.Interfaces.Context;
using KarinShop.Application.Interfaces.FacadPatterns;
using KarinShop.Application.Services.Products.Queries.GetChildCategories;
using KarinShop.Common.Classes;
using KarinShop.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace KarinShop.Application.Services.Products.Queries.GetProductListForSite
{
    public interface IGetProductListForSite
    {
        ResultDto<ResultGetProductListForSite> Execute(Ordering  ordering,string SerachKey ,int Page, int PageSize, long? CatID = null);
    }
    public class GetProductListForSiteServices : IGetProductListForSite
    {
        private readonly IGetChildCategories _getChildCategories;
        private readonly IDataBaseContext _context;
        public GetProductListForSiteServices(IDataBaseContext context, IGetChildCategories getChildCategories)
        {
            _context = context;
            _getChildCategories = getChildCategories;
        }
        public ResultDto<ResultGetProductListForSite> Execute(Ordering ordering, string SearchKey, int Page,int PageSize, long? CatID = null)
        {
            int totalRow = 0;
            var ProductQuery = _context.Products
                .Include(p => p.ProductImage)
                .Include(p => p.Category)
                .AsQueryable();
            if (CatID != null)
            {
                var IDs = _getChildCategories.Execute(CatID.Value).Data;

                ProductQuery = ProductQuery.Where(p => IDs.Contains(p.CategoryID)).AsQueryable();

            }
            if(!string.IsNullOrWhiteSpace(SearchKey))
            {
               ProductQuery = ProductQuery.Where(p => p.Name.Contains(SearchKey) || p.Brand.Contains(SearchKey)).AsQueryable();
            }
            switch (ordering)
            {
                case Ordering.Newest:
                    ProductQuery = ProductQuery.OrderByDescending(p => p.ID).AsQueryable();
                    break;
                case Ordering.MostViewed:
                    ProductQuery = ProductQuery.OrderByDescending (p => p.ViewCount).AsQueryable();
                    break;
                case Ordering.Exepensivest:
                    ProductQuery = ProductQuery.OrderByDescending(p => p.Price).AsQueryable();
                    break;
                case Ordering.Cheapest:
                    ProductQuery = ProductQuery.OrderBy(p => p.Price).AsQueryable();
                    break;
            }
            var Products = ProductQuery.ToPaged(Page, PageSize, out totalRow);
            return new ResultDto<ResultGetProductListForSite>
            {
                Data = new ResultGetProductListForSite
                {
                    Product = Products.Select(p => new GetProductListForSiteDto
                    {
                        ID = p.ID,
                        Title = p.Name,
                        ImageSrc = p.ProductImage.FirstOrDefault()?.Src ?? "",
                        Price = p.Price,
                    }).ToList(),
                    TotalRow = totalRow
                },
            };

        }
    }
    public enum Ordering
    {
        MostViewed = 0,
        Newest = 1,
        Exepensivest = 2,
        Cheapest = 3,
    }
    public class ResultGetProductListForSite
    {
        public List<GetProductListForSiteDto> Product { get; set; }
        public int TotalRow { get; set; }
    }
    public class GetProductListForSiteDto
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string ImageSrc { get; set; }
        public int Price { get; set; }
    }
}
