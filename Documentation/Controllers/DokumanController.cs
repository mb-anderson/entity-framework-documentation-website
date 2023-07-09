using Microsoft.AspNetCore.Mvc;
using Documentation.Service.Core;
using Documentation.Service.Models;


namespace Documentation.Controllers
{
    public class DokumanController : Controller
    {

        private readonly DokumanService _DokumanService;
        private readonly CategoryService _categoryService;




        public DokumanController(DokumanService DokumanService, CategoryService categoryService)
        {
            _DokumanService = DokumanService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {

            var models = _DokumanService.GetAll();

            return View(models);
        }

        public IActionResult Create()
        {
            ViewBag.CategoryList = _categoryService.GetAll();
            return View();
        }
        [HttpGet("/Dokuman/Update/{id}")]
        public IActionResult Update(int id)
        {
            ViewBag.CategoryList = _categoryService.GetAll();
            Dokuman dokuman = _DokumanService.GetById(id);
            return View(dokuman);
        }
        public IActionResult UpdateAction(Dokuman model)
        {

            _DokumanService.Update(model);
            TempData["success"] = "Doküman Başarılı Bir Şekilde Güncellendi";
            return RedirectToAction("Index");
        }
        public IActionResult SaveAction(Dokuman model)
        {

            _DokumanService.Save(model);

            TempData["success"] = "Doküman Başarılı Bir Şekilde Kaydedildi";
            return RedirectToAction("Index");
        }
        public IActionResult DeleteAction(int id)
        {
            _DokumanService.Delete(id);
            TempData["success"] = "Doküman Başarılı Bir Şekilde Silindi";
            return RedirectToAction("Index");
        }
    }
}
