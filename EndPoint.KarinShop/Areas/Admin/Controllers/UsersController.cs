using KarinShop.Application.Interfaces.FacadPatterns.User;
using KarinShop.Application.Services.Users.Commands.EditUsers;
using KarinShop.Application.Services.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EndPoint.KarinShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
       private readonly IUserFacade _userFacade;
        public UsersController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        public IActionResult index(string SearchKey, int page = 1)
        {
            return View(_userFacade.getUsers.Execute(new RequestUsersDto

            {
                SearchKey = SearchKey,
                Page = page
            }
                ));
        }
        [HttpPost]
        public IActionResult Delete(int UserID)
        {

            return Json(_userFacade.removeUsers.Execute(UserID));
        }

        [HttpPost]
        public IActionResult UserStatusChange(int UserID)
        {
            return Json(_userFacade.userStatusChange.Execute(UserID));
        }

        [HttpPost]
        public IActionResult Edit(int UserID, string Name)
        {
            return Json(_userFacade.editUsers.Execute(new RequestEditUser
            {
                Name = Name,
                UserID = UserID
            }));
        }
        
        [HttpGet]
        public IActionResult AddNewUsers()
        {
            ViewBag.Roles = new SelectList(_userFacade.getRoles.Execute().Data, "RoleID", "RoleName");
            return View();
        }

    }
}
