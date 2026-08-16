using KarinShop.Application.Interfaces.Context;
using KarinShop.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarinShop.Application.Services.Users.Queries.GetRoles
{
    public class GetRolesServices : IGetUserRoles
    {
        private readonly IDataBaseContext _context;
        public GetRolesServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<RolesDto>> Execute()
        {
            var Roles = _context.Roles.ToList().Select(p => new RolesDto
            {
                RoleID = p.RoleID,
                RoleName = p.RoleName,
            }).ToList();
            return new ResultDto<List<RolesDto>>()
            {
                Data = Roles,
                IsSuccess = true,

            };
        }
    }
}
