using KarinShop.Application.Interfaces.Context;
using KarinShop.Common.Dto;
using KarinShop.Domain.Entities.Products;
using Microsoft.IdentityModel.Tokens;

namespace KarinShop.Application.Services.Products.Commands.AddCategory
{
    public interface IAddNewCategory
    {
        ResultDto Execute(int? ParentID, string Name);
    }
    public class AddNewCategoryServices : IAddNewCategory
    {
        private readonly IDataBaseContext _context;
        public AddNewCategoryServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(int? ParentID, string Name)
        {
            if(string.IsNullOrWhiteSpace(Name))
            {
                return new ResultDto
                {
                    IsSuccess = false
                    ,
                    Message = "لطفا نام را به درستی وارد کنید"
                };
            }
            Category category = new Category()
            {
                CategoryName = Name,
                ParentCategoryID = ParentID,
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "دسته بندی با موفقیت اضافه شد"
            };
          
        }

    }
}
