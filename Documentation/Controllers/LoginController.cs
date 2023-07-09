using Microsoft.AspNetCore.Mvc;
using Documentation.Service.Core;
using Documentation.Service.Models;

namespace Documentation.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserService _UserService;
        private readonly RoleService _roleService;

        public LoginController(UserService UserService, RoleService roleService)
        {
            _UserService = UserService;
            _roleService = roleService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginAction(string username, string password)
        {

            User user = _UserService.GetByUsername(username);
            if (user != null)
            {
                bool girisBasarili = UserService.VerifyPassword(password, user.Password);
                if (girisBasarili)
                {
                    HttpContext.Session.SetString("Username", username);
                    Console.WriteLine(HttpContext.Session.GetString("Username"));
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "Geçersiz kullanıcı adı veya şifre";
                    return View("Login");
                }
            }
            return View();
        }




    }
}
