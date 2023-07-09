using Microsoft.AspNetCore.Mvc;
using Documentation.Service.Core;
using Documentation.Service.Models;


namespace Documentation.Controllers
{
    public class CategoryController : Controller
    {

        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {

            var models = _categoryService.GetAll();
            return View(models);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpGet("/Category/Update/{id}")]
        public IActionResult Update(int id)
        {
            Category category = _categoryService.GetById(id);
            return View(category);
        }
        public IActionResult UpdateAction(Category model)
        {
            _categoryService.Update(model);
            TempData["success"] = "Kategori Başarılı Bir Şekilde Güncellendi";
            return RedirectToAction("Index");

        }
        public IActionResult Save(Category model)
        {
            _categoryService.Save(model);

            TempData["success"] = "Kategori Başarılı Bir Şekilde Kaydedildi";
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            TempData["success"] = "Kategori Başarılı Bir Şekilde Silindi";
            return RedirectToAction("Index");
        }
    }
}
