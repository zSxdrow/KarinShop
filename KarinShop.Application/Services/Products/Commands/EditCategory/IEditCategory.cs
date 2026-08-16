using KarinShop.Application.Interfaces.Context;
using KarinShop.Common.Dto;

namespace KarinShop.Application.Services.Products.Commands.EditCategory
{
    public interface IEditCategory
    {
        ResultDto Execute(RequestEditCategory request);
    }
    public class EditCategoryServices : IEditCategory
    {
        private readonly IDataBaseContext _context;
        public EditCategoryServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestEditCategory request)
        {
            var Category = _context.Categories.Find(request.CategoryID);
            if(Category == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "دسته بندی یافت نشد"
                };
            }
            Category.CategoryName = request.Name;
            Category.UpdateTime = DateTime.Now;
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "کاربر با موفقیت ویرایش شد"
            };
        }
    }

    public class RequestEditCategory()
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
    }
}
