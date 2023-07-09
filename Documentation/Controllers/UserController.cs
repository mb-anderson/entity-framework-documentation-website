using Microsoft.AspNetCore.Mvc;
using Documentation.Service.Core;
using Documentation.Service.Models;

namespace Documentation.Controllers
{
    public class UserController : Controller
    {

        private readonly UserService _UserService;
        private readonly RoleService _roleService;




        public UserController(UserService UserService, RoleService roleService)
        {
            _UserService = UserService;
            _roleService = roleService;
        }
        public IActionResult Index()
        {

            var models = _UserService.GetAll();

            return View(models);
        }

        public IActionResult Create()
        {
            ViewBag.RoleList = _roleService.GetAll();
            return View();
        }
        [HttpGet("/User/Update/{id}")]
        public IActionResult Update(int id)
        {
            ViewBag.RoleList = _roleService.GetAll();
            User user = _UserService.GetById(id);
            return View(user);
        }
        public IActionResult UpdateAction(User model)
        {
            if (model.Password != null && !model.Password.Equals(""))
            {
                model.Password = UserService.HashPassword(model.Password);
            }
            else
            {
                model.Password = _UserService.GetById(model.UserID).Password;
            }
            _UserService.Update(model);
            TempData["success"] = "Kullanıcı Başarılı Bir Şekilde Güncellendi";
            return RedirectToAction("Index");
        }
        public IActionResult SaveAction(User model)
        {
            if (model.Password != null && !model.Password.Equals(""))
            {
                model.Password = UserService.HashPassword(model.Password);
            }
            else
            {
                model.Password = _UserService.GetById(model.UserID).Password;
            }
            _UserService.Save(model);
            TempData["success"] = "Kullanıcı Başarılı Bir Şekilde Kaydedildi";
            return RedirectToAction("Index");
        }
        public IActionResult DeleteAction(int id)
        {
            _UserService.Delete(id);
            TempData["success"] = "Kullanıcı Başarılı Bir Şekilde Silindi";
            return RedirectToAction("Index");
        }


    }
}
