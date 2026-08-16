using KarinShop.Application.Interfaces.Context;
using KarinShop.Common.Dto;
using KarinShop.Domain.Entities.User;
using System.Text.RegularExpressions;

namespace KarinShop.Application.Services.Users.Commands.RegisterUsers
{
    public class RegisterUsersService : IRegisterUsersService
    {
        private readonly IDataBaseContext _context;
        public RegisterUsersService(IDataBaseContext context)
        {
            _context = context;
        }



        public  ResultDto<ResultRegisterUsersDto> Execute(RequestRegisterUserDto request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Name) ||
                    string.IsNullOrWhiteSpace(request.UserName) ||
                    string.IsNullOrWhiteSpace(request.Password) ||
                        string.IsNullOrWhiteSpace(request.RePassword))
                {
                    return new ResultDto<ResultRegisterUsersDto>
                    {
                        Data = new ResultRegisterUsersDto { },
                        IsSuccess = false,
                        Message = "لطفا تمامی موارد را وارد کنید"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.Name))
                {
                    return new ResultDto<ResultRegisterUsersDto>
                    {
                        Data = new ResultRegisterUsersDto() { UserID = 0 },
                        IsSuccess = false,
                        Message = "نام را وارد نمایید"


                    };

                }
                if (string.IsNullOrWhiteSpace(request.UserName))
                {
                    return new ResultDto<ResultRegisterUsersDto>
                    {
                        Data = new ResultRegisterUsersDto { UserID = 0 },
                        IsSuccess = false,
                        Message = "نام کاربری را وارد نمایید",
                    };
                }

                if(request.Password.Length < 8)
                {
                    return new ResultDto<ResultRegisterUsersDto>
                    {
                        Data = new ResultRegisterUsersDto { UserID = 0 },
                        IsSuccess = false,
                        Message = "رمز عبور نمیتواند کمتر از 8 کاراکتر باشد"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.Password))
                {
                    return new ResultDto<ResultRegisterUsersDto>()
                    {
                        Data = new ResultRegisterUsersDto { UserID = 0 },
                        IsSuccess = false,
                        Message = "رمز عبو را وارد نمایید"
                    };
                }
                if (request.RePassword != request.Password)
                {
                    return new ResultDto<ResultRegisterUsersDto>()
                    {
                        Data = new ResultRegisterUsersDto { UserID = 0 },
                        IsSuccess = false,
                        Message = "رمز عبور با تکرار آن مطابقت ندارد"
                    };

                }
                 string unameRegex = @"^[A-Za-z][A-Za-z0-9_]*[A-Za-z0-9]$";
                var match = Regex.Match(request.UserName, unameRegex, RegexOptions.IgnoreCase);

                if (!match.Success)
                {
                    return new ResultDto<ResultRegisterUsersDto> { Data = new ResultRegisterUsersDto { }, IsSuccess = false, Message = "لطفا نام کاربری را به درستی وارد کنید " };
                }
                User user = new User()
                {
                    Name = request.Name,
                    UserName = request.UserName,
                    Password = request.Password,
                    RePassword = request.RePassword,
                };
                List<UserInRole> userInRoles = new List<UserInRole>();
                foreach (var item in request.Roles)
                {
                    var Roles = _context.Roles.Find(item.RoleID);
                    userInRoles.Add(new UserInRole
                    {
                        Role = Roles,
                        RoleID = Roles.RoleID,
                        User = user,
                        UserID = user.ID,
                    });

                    user.UserInRoles = userInRoles;
                }
                    _context.Users.Add(user);
                     _context.SaveChanges();
 

                return new ResultDto<ResultRegisterUsersDto>
                {
                    Data = new ResultRegisterUsersDto()
                    {
                        UserID = user.ID
                    },
                    IsSuccess = true,
                    Message = "کاربر با موفقیت ثبت نام شد"
               };


            }
            catch(Exception ex)
            {
               
                return new ResultDto<ResultRegisterUsersDto>
                {
                    Data = new ResultRegisterUsersDto()
                    { UserID = 0 },
                    IsSuccess = false,
                    Message = "ثبت نام کاربر با موفقیت انجام نشد!"
                };

            }

        }
    }


}
