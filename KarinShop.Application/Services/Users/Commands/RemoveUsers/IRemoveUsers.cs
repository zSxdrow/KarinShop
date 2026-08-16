using KarinShop.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarinShop.Application.Services.Users.Commands.RemoveUsers
{
    public interface IRemoveUsers
    {
        ResultDto Execute(int UserID);
    }
}
