using KarinShop.Application.Interfaces.Context;
using KarinShop.Application.Interfaces.FacadPatterns.User;
using KarinShop.Application.Services.Users.Commands.EditUsers;
using KarinShop.Application.Services.Users.Commands.RegisterUsers;
using KarinShop.Application.Services.Users.Commands.RemoveUsers;
using KarinShop.Application.Services.Users.Commands.UserStatusChange;
using KarinShop.Application.Services.Users.Queries.GetRoles;
using KarinShop.Application.Services.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Hosting;

namespace KarinShop.Application.Services.Users.Facade
{
    public class UserFacade : IUserFacade
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public UserFacade(IDataBaseContext context)
        {
            _context = context;
        }
        private IGetUserRoles _getRoles;
        public IGetUserRoles getRoles
        {
            get
            {
                return _getRoles = _getRoles ?? new GetRolesServices(_context);
            }
        }

        private IGetUsers _getUsers;
        public IGetUsers getUsers
        {
            get
            {
                return _getUsers = _getUsers ?? new GetUsersService(_context);
            }
        }

        private RemoveUserServices _removeUsers;
        public RemoveUserServices removeUsers
        {
            get
            {
                return _removeUsers = _removeUsers ?? new RemoveUserServices(_context);
            }
        }

        private RegisterUsersService _registerUsers;
        public RegisterUsersService registerUsers
        {
            get
            {
                return _registerUsers = _registerUsers?? new RegisterUsersService(_context);
            }
        }

        private UserStatusChangeServices _userStatusChange;
        public UserStatusChangeServices userStatusChange
        {
            get
            {
                return _userStatusChange = _userStatusChange ?? new UserStatusChangeServices(_context);
            }
        }

        private EditUsersServices _editUsers;
        public EditUsersServices editUsers
        {
            get
            {
                return _editUsers = _editUsers ?? new EditUsersServices(_context);
            }
        }
    }
}
