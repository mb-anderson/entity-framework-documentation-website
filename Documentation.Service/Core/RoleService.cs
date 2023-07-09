using Documentation.Service.Models;
using Documentation.Service.Veritabani;

namespace Documentation.Service.Core
{
    public class RoleService
    {
        private readonly AppDbContext _db;

        public RoleService(AppDbContext db)
        {
            _db = db;
        }

        public Role GetById(int id)
        {
            return _db.roles.First(p => p.RoleID == id);
        }

        public List<Role> GetAll()
        {
            var roles = _db.roles.ToList();

            return roles;
        }

        public void Save(Role model)
        {
            _db.roles.Add(model);

            _db.SaveChanges();

        }
        public void Update(Role model)
        {

            _db.Update(model);
            _db.SaveChanges();

        }
        public void Delete(int id)
        {
            var model = _db.roles.Find(id);
            _db.roles.Remove(model);
            _db.SaveChanges();
        }
    }
}
