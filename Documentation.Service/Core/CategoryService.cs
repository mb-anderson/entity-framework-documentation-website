using Documentation.Service.Models;
using Documentation.Service.Veritabani;

namespace Documentation.Service.Core
{
    public class CategoryService
    {
        private readonly AppDbContext _db;

        public CategoryService(AppDbContext db)
        {
            _db = db;
        }

        public Category GetById(int id)
        {
            return _db.categories.First(p => p.CategoryID == id);
        }

        public List<Category> GetAll()
        {
            var models = _db.categories.ToList();
            return models;
        }

        public void Save(Category model)
        {
            _db.categories.Add(model);
            _db.SaveChanges();

        }

        public void Update(Category model)
        {

            _db.Update(model);
            _db.SaveChanges();

        }
        public void Delete(int id)
        {
            var model = _db.categories.Find(id);
            _db.categories.Remove(model);
            _db.SaveChanges();
        }
    }
}
