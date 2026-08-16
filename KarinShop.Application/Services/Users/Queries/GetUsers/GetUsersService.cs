using KarinShop.Application.Interfaces.Context;


namespace KarinShop.Application.Services.Users.Queries.GetUsers
{
    public class GetUsersService : IGetUsers
    {
        private readonly IDataBaseContext _context;
        public GetUsersService( IDataBaseContext context)
        {
            _context = context;
        }


        public ResultGetUserDto Execute(RequestUsersDto requestUsers)
        {
            var users = _context.Users.AsQueryable();
            if(!string.IsNullOrWhiteSpace(requestUsers.SearchKey) )
            {
                users = users.Where(p => p.Name.Contains(requestUsers.SearchKey) || p.UserName.Contains(requestUsers.SearchKey));
            }
            
            var UsersEnd = users.Select(p => new GetUsersDto
            {
                ID = p.ID,
                Name = p.Name,
                UserName = p.UserName,
                IsActive = p.IsActive,
            }).ToList();
            return new ResultGetUserDto
            {
                
                Users = UsersEnd,
            };

        }
    }

}
