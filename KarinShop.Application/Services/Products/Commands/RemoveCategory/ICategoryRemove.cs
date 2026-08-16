using KarinShop.Application.Interfaces.Context;
using KarinShop.Common.Dto;

namespace KarinShop.Application.Services.Products.Commands.RemoveCategory
{
    public interface ICategoryRemove
    {
        ResultDto Execute(int CategoryID);
    }

    public class CategoryRemoveServices : ICategoryRemove
    {
        private readonly IDataBaseContext _context;
        public CategoryRemoveServices(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(int CategoryID)
        {
            var Category = _context.Categories.Find(CategoryID);
            if(Category == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "دسته بندی یافت نشد"
                };
            }
            Category.IsRemoved = true;
            Category.RemoveTime = DateTime.Now;
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "دسته بندی با موفقیت حذف شد"
            };

        }
    }
}

