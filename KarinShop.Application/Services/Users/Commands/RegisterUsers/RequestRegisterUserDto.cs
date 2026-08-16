namespace KarinShop.Application.Services.Users.Commands.RegisterUsers
{
    public class RequestRegisterUserDto
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public List<RolesInRegisterUsersDto> Roles {  get; set; }
    }



}
