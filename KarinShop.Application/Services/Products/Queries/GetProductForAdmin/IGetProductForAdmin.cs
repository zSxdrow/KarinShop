using KarinShop.Application.Interfaces.Context;
using KarinShop.Common.Classes;
using KarinShop.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace KarinShop.Application.Services.Products.Queries.GetProductForAdmin
{
    public interface IGetProductForAdmin
    {
        ResultDto<ListProductForAdminDto> Execute(int Page = 1, int pageSize = 20);
    }
    public class GetPRoductForAdminServices : IGetProductForAdmin
    {
        private readonly IDataBaseContext _context;
        public GetPRoductForAdminServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ListProductForAdminDto> Execute(int Page = 1, int pageSize = 20)
        {
            int rowCount = 0;
            var products = _context.Products
                .Include(p => p.Category)
                .ToPaged(Page, pageSize, out rowCount)
                .Select(p => new ProductForAdminList_Dto
                {
                    ID = p.ID,
                    Name = p.Name,
                    Brand = p.Brand,
                    Description = p.Description,
                    Category = p.Category.CategoryName,
                    Displayed = p.Displayed,
                    Inventory = p.Inventory,
                    Price = p.Price,
                }).ToList();

            return new ResultDto<ListProductForAdminDto>
            {
                Data = new ListProductForAdminDto
                {
                    CurrentPage = Page,
                    PageSize = pageSize,
                    RowCount = rowCount,
                    Products = products
                }
            };
        }
    }

    public class ListProductForAdminDto
    {
        public int RowCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<ProductForAdminList_Dto> Products { get; set; }

    }

    public class ProductForAdminList_Dto
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool Displayed { get; set; }
    }
}
