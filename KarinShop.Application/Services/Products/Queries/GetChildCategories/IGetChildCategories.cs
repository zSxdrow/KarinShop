using KarinShop.Application.Interfaces.Context;
using KarinShop.Common.Dto;
using NuGet.Packaging.Signing;

namespace KarinShop.Application.Services.Products.Queries.GetChildCategories
{
    public interface IGetChildCategories
    {
        ResultDto<List<long>> Execute(long ParID);
    }
    public class GetChildCategoriesServices : IGetChildCategories
    {
        private readonly IDataBaseContext _context;
        public GetChildCategoriesServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<long>> Execute(long ParID)
        {
            var IDs = new List<long>();
            IDs.Add(ParID);
            var Childs = _context.Categories
                .Where(p => p.ParentCategoryID == ParID)
                .ToList();
            foreach (var child in Childs)
            {
                IDs.Add(child.ID);
            }
            return new ResultDto<List<long>>
            {
                Data = IDs,
                IsSuccess = true,
            };

        }
    }

}
