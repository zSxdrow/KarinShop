using KarinShop.Application.Interfaces.Context;
using KarinShop.Common.Dto;

namespace KarinShop.Application.Services.Users.Commands.EditUsers
{
    public class EditUsersServices : IEditUsers
    {
        private readonly IDataBaseContext _context;
        public EditUsersServices(IDataBaseContext context)
        {
           _context = context; 
        }


        public ResultDto Execute(RequestEditUser request)
        {
            var user = _context.Users.Find(request.UserID);
            if(user == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "لطفا مقدار را وارد کنید"
                };
            }
            user.Name = request.Name;
            user.UpdateTime = DateTime.Now;
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "کاربر با موفقیت ویرایش شد"

            };
        }


    }

}
