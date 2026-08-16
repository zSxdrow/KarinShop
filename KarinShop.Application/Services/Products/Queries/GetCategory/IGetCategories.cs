using KarinShop.Application.Interfaces.Context;
using KarinShop.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace KarinShop.Application.Services.Products.Queries.GetCategory
{
    public interface IGetCategories
    {
        ResultDto<List<CategoriesDto>> Execute(int? ParentID);
    }

    public class GetCategoryServices : IGetCategories
    {
    private readonly IDataBaseContext _context;
        public GetCategoryServices(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<CategoriesDto>> Execute(int? ParentID)
        {
            var result = _context.Categories
                .Include(p => p.ParentCategory)
                .Include(p => p.ChildCategories)
                .Where(p => p.ParentCategoryID.Equals(ParentID))
                .Select(p => new CategoriesDto
            {
                ID = p.ID,
                Name = p.CategoryName,
                parent = p.ParentCategory != null
                    ? new parentCategoryDto
                    {
                      
                        ParentID = p.ParentCategory.ID,
                        ParentName = p.ParentCategory.CategoryName,
                    }
                    : null,
                 HasChild = p.ChildCategories.Count() > 0 ? true : false,
            }).ToList();
                

            return new ResultDto<List<CategoriesDto>>
            {
                Data = result,
                IsSuccess = true,
                Message = "دسته بندی با موفقیت ساخته شد"
            };
       }
    }


    public class CategoriesDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool HasChild { get; set; }
        public parentCategoryDto parent { get; set; }
    }
    
    public class parentCategoryDto
    {
        public int? ParentID { get; set; }
        public string ParentName { get; set; }

    }

}
