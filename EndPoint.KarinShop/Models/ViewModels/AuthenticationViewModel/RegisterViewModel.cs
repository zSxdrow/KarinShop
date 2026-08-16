using Microsoft.AspNetCore.Mvc;

namespace EndPoint.KarinShop.Models.ViewModels.AuthenticationViewModel
{
    public class RegisterViewModel
    {
        
        public string Name { get; set; } = "";
        public string UserName { get; set; }
        public string Password{ get; set; }
        public string RePassword { get; set; }
    }
}
