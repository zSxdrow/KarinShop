using KarinShop.Application.Interfaces.Context;
using KarinShop.Common.Dto;

namespace KarinShop.Application.Services.Users.Commands.UserStatusChange
{
    public class UserStatusChangeServices : IUserStatusChange
    {
        private readonly IDataBaseContext _context;
        public UserStatusChangeServices(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(int UserID)
        {
            var user = _context.Users.Find(UserID);
            if(user == null)
            {
                return new ResultDto
                { IsSuccess = false,
                Message = "کاربر یافت نشد"
                };

            }

            user.IsActive = !user.IsActive;
            _context.SaveChanges();
            string UserStatus = user.IsActive == true ? "فعال" : "غیرفعال";
            return new ResultDto
            { 
            IsSuccess = true,
             Message = $"کاربر با موفقیت {UserStatus} شد. "
            };


        }
    }

}
