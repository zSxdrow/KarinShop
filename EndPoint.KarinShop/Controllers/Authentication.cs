using EndPoint.KarinShop.Models.ViewModels.AuthenticationViewModel;
using KarinShop.Application.Interfaces.FacadPatterns.User;
using KarinShop.Application.Services.Users.Commands.RegisterUsers;
using KarinShop.Application.Services.Users.Commands.UserLogin;
using KarinShop.Common.Dto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
//var p5min = DateTime.Now;

namespace EndPoint.KarinShop.Controllers
{
    public class Authentication : Controller
    {
        #region Variables

        private readonly IUserFacade _userFacade;
        private readonly IUserLogin _userLogin;

        #endregion

        #region Constructor
        public Authentication(IUserFacade userFacade , IUserLogin userLogin)
        {
            _userFacade = userFacade;
            _userLogin = userLogin;
        }
        #endregion
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(SignUpViewModel request)
        {
            if ( User.Identity.IsAuthenticated)
            {
                return Json(new ResultDto { IsSuccess = false, Message = "درحال حاضر شما نمیتوانید ثبت نام مجدد کنید" });
            }
            var SignUpResult = _userFacade.registerUsers.Execute(new RequestRegisterUserDto
            {
                Name = request.Name,
                UserName = request.UserName,
                Password = request.Password,
                RePassword = request.RePassword,
                Roles = new List<RolesInRegisterUsersDto>()
                { new RolesInRegisterUsersDto{RoleID = 3}}
            });
            //login
            if(SignUpResult.IsSuccess)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, SignUpResult.Data.UserID.ToString()),
                    new Claim(ClaimTypes.Email , request.UserName),
                    new Claim (ClaimTypes.Name , request.Name),
                    new Claim(ClaimTypes.Role , "Customer"),
                };
                var Identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var Principal = new ClaimsPrincipal(Identity);
                var Properties = new AuthenticationProperties()
                {                   
                    IsPersistent = true,
                };
                await HttpContext.SignInAsync(Principal, Properties);
            }
            return Json(SignUpResult);
        }
       [HttpGet]
        public IActionResult Index()
        {
           return View();
        }
        [HttpPost]
        public IActionResult SignIn(string UserName , string Password )
        {
            var result = _userLogin.Execute(UserName, Password);
            if(result.IsSuccess)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, result.Data.UserID.ToString()),
                    new Claim(ClaimTypes.Email , UserName),
                    new Claim(ClaimTypes.Name , result.Data.Name),
                    new Claim(ClaimTypes.Role , result.Data.Roles)
                };
                var identity = new ClaimsIdentity (claims , CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {   
                    IsPersistent = true,
                    ExpiresUtc = DateTime.Now.AddDays(5)
                };
                HttpContext.SignInAsync(principal, properties);
            }
            return Json(result);
        }
           public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index" , "home");
        }

    }
}
