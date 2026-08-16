using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarinShop.Application.Services.Users.Queries.GetUsers
{
    public interface IGetUsers
    {
        ResultGetUserDto Execute(RequestUsersDto request);

    }

}
