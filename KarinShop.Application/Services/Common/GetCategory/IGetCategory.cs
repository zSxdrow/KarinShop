using KarinShop.Application.Interfaces.Context;
using KarinShop.Common.Dto;

namespace KarinShop.Application.Services.Common.GetCategory
{
    public interface IGetCategory
    {
        ResultDto<List<GetCategoryDto>> Execute();
    }
    public class GetCategoryServices : IGetCategory
    {
        private readonly IDataBaseContext _context;
        public GetCategoryServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<GetCategoryDto>> Execute()
        {
            var Category = _context.Categories
                .Where(p => p.ParentCategoryID == null)
                .Select(p => new GetCategoryDto
                {
                    ID = p.ID,
                    Name = p.CategoryName,
                }).ToList();

            return new ResultDto<List<GetCategoryDto>>
            {
                Data = Category
            };
        }
    }

    public class GetCategoryDto
    {
        public long ID { get; set; }
        public string Name { get; set; }

    }
}
