using Microsoft.EntityFrameworkCore;
using Documentation.Service.Models;
using Documentation.Service.Veritabani;

namespace Documentation.Service.Core
{
    public class DokumanService
    {
        private readonly AppDbContext _db;

        public DokumanService(AppDbContext db)
        {
            _db = db;
        }

        public Dokuman GetById(int id)
        {
            return _db.documents.First(p => p.DokumanID == id);
        }

        public List<Dokuman> GetAll()
        {
            var dokumans = _db.documents
                .Include(d => d.Category)
                .ToList();

            return dokumans;
        }

        public void Save(Dokuman model)
        {
            _db.documents.Add(model);

            _db.SaveChanges();

        }
        public void Update(Dokuman model)
        {

            _db.Update(model);
            _db.SaveChanges();

        }
        public void Delete(int id)
        {
            var model = _db.documents.Find(id);
            _db.documents.Remove(model);
            _db.SaveChanges();
        }
    }
}
