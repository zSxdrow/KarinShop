using KarinShop.Common.Dto;
using Microsoft.EntityFrameworkCore.Storage;

namespace KarinShop.Application.Services.Users.Queries.GetRoles
{
    public interface IGetUserRoles
    {
        public ResultDto<List<RolesDto>> Execute();
    }
}
