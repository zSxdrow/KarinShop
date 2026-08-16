using KarinShop.Application.Interfaces.Context;
using KarinShop.Common.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarinShop.Application.Services.Products.Queries.GetAllCategories
{
    public interface IGetAllCategories
    {
        ResultDto<List<AllCategoriesDto>> Execute();
    }
    public class GetAllCategoriesServices : IGetAllCategories
    {
        private readonly IDataBaseContext _context;
        public GetAllCategoriesServices(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<AllCategoriesDto>> Execute()
        {

            var categories = _context.Categories
                .Include(p => p.ParentCategory)
                .Where(p => p.ParentCategoryID != null)
                .ToList()
                .Select(p => new AllCategoriesDto
                {
                    ID = p.ID,
                    Name = $"{p.ParentCategory?.CategoryName}  - {p.CategoryName}",
                }).ToList();

            return new ResultDto<List<AllCategoriesDto>>
            {
                Data = categories,
                IsSuccess = true,
                Message = ""
            };
        }
    }
    public class AllCategoriesDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

}
