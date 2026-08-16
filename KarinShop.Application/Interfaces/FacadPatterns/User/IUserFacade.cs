using KarinShop.Application.Services.Users.Commands.EditUsers;
using KarinShop.Application.Services.Users.Commands.RegisterUsers;
using KarinShop.Application.Services.Users.Commands.RemoveUsers;
using KarinShop.Application.Services.Users.Commands.UserStatusChange;
using KarinShop.Application.Services.Users.Queries.GetRoles;
using KarinShop.Application.Services.Users.Queries.GetUsers;

namespace KarinShop.Application.Interfaces.FacadPatterns.User
{
    public interface IUserFacade
    {
        public IGetUserRoles getRoles { get; }
        public IGetUsers getUsers { get; }
        public RemoveUserServices removeUsers { get; }
        public RegisterUsersService registerUsers { get; }
        public UserStatusChangeServices userStatusChange { get; }
        public EditUsersServices editUsers { get; }
     
       
        
    }
}
