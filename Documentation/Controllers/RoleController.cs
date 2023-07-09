using Microsoft.AspNetCore.Mvc;
using Documentation.Service.Core;
using Documentation.Service.Models;


namespace Documentation.Controllers
{
    public class RoleController : Controller
    {

        private readonly RoleService _roleService;

        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }
        public IActionResult Index()
        {

            var models = _roleService.GetAll();
            return View(models);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpGet("/Role/Update/{id}")]
        public IActionResult Update(int id)
        {
            Role role = _roleService.GetById(id);
            return View(role);
        }
        public IActionResult UpdateAction(Role model)
        {
            _roleService.Update(model);
            TempData["success"] = "Rol Başarılı Bir Şekilde Güncellendi";
            return RedirectToAction("Index");

        }
        public IActionResult Save(Role model)
        {
            _roleService.Save(model);

            TempData["success"] = "Rol Başarılı Bir Şekilde Kaydedildi";
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _roleService.Delete(id);
            TempData["success"] = "Rol Başarılı Bir Şekilde Silindi";
            return RedirectToAction("Index");
        }
    }
}
