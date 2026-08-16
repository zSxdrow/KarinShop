using KarinShop.Common.Dto;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarinShop.Application.Services.Users.Commands.EditUsers
{
    public interface IEditUsers
    {
        ResultDto Execute(RequestEditUser request);
    }

}
