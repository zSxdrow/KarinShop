using KarinShop.Common.Dto;

namespace KarinShop.Application.Services.Users.Commands.UserStatusChange
{
    public interface IUserStatusChange
    {
        ResultDto Execute(int UserID);

    }

}
