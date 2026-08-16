using KarinShop.Common.Dto;

namespace KarinShop.Application.Services.Users.Commands.RegisterUsers
{
    public interface IRegisterUsersService
    {
        ResultDto<ResultRegisterUsersDto> Execute(RequestRegisterUserDto request);


    }
    //public enum RolesInRegisterUsersDtoType 
    //{
    //   Customer = 0,
    //   Admin = 1,
    //   Owner = 2,


    //}


}
