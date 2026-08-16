using KarinShop.Application.Interfaces.Context;
using KarinShop.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace KarinShop.Application.Services.Users.Commands.UserLogin
{
    public interface IUserLogin
    {
        ResultDto<ResultUserLogin> Execute(string UserName, string Password);
    }



    public class UserLoginServices : IUserLogin
    {
        private readonly IDataBaseContext _context;
        public UserLoginServices(IDataBaseContext context)
        {
            _context = context;
        }


        public ResultDto<ResultUserLogin> Execute(string UserName, string Password)
        {
            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Password))
            {


                return new ResultDto<ResultUserLogin>()
                {
                    Data = new ResultUserLogin { },
                    IsSuccess = false,
                    Message = "لطفا نام کاربری و رمز عبور خود را وارد نمایید"

                };
            }
            var users = _context.Users.Include(p => p.UserInRoles)
                .ThenInclude(p => p.Role).Where
                (p => p.UserName.Equals(UserName) && p.IsActive == true)
                .FirstOrDefault();
            if(users == null)
            {
                return new ResultDto<ResultUserLogin>
                {
                    Data = new ResultUserLogin { },
                    IsSuccess = false,
                    Message = "کاربری با این نام کاربری در سایت افغانستان ثبت نام نکَردَ است."
                };
            }
            bool VerifyPassword = IsTrue(Password , users.Password);
            bool IsTrue(string pass1 , string pass2)
            {
                 return pass1.Equals(pass2);
            }
            if(!VerifyPassword)
            {
                return new ResultDto<ResultUserLogin>
                {
                    Data = new ResultUserLogin { },
                    IsSuccess = false,
                    Message = "رمز عبور اشتباه است"
                };
            }
            var role = "";
            foreach(var item in users.UserInRoles)
            {
                role += $"{item.Role.RoleName}";
            }

            return new ResultDto<ResultUserLogin>
            {
                Data = new ResultUserLogin
                {
                    UserID = users.ID,
                    Name = users.Name,
                    Roles = role
                },
                IsSuccess = true,
                Message = "خوش آمدید"
            };
            
        }
    }
    public class ResultUserLogin
    {
        public int UserID { get; set; }
        public string Roles { get; set; }
        public string Name { get; set; }
    }
}
