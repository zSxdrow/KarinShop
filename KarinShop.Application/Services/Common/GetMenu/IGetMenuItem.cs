using KarinShop.Application.Interfaces.Context;
using KarinShop.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace KarinShop.Application.Services.Common.GetMenu
{
    public interface IGetMenuItem
    {
        ResultDto<List<GetMenuItemDto>> Execute();
    }

    public class GetMenuItemServices : IGetMenuItem
    {
        private readonly IDataBaseContext _context;
        public GetMenuItemServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<GetMenuItemDto>> Execute()
        {
            var result = _context.Categories.Include(p => p.ChildCategories)
                 .Where(p => p.ParentCategoryID == null)
                 .ToList()
                 .Select(p => new GetMenuItemDto
                 {
                     CatID = p.ID,
                     Name = p.CategoryName,
                     Child = p.ChildCategories.ToList().Select(p => new GetMenuItemDto
                     {
                         CatID = p.ID,
                         Name = p.CategoryName,
                     }).ToList()
                 }).ToList();
            return new ResultDto<List<GetMenuItemDto>>
            {
                Data = result
            }; 
        }
    }

    public class GetMenuItemDto
    {
        public long CatID { get; set; }
        public string Name { get; set; }
        public List<GetMenuItemDto> Child { get; set; }
    }
}
