using Documentation.Service.Models;
using Documentation.Service.Veritabani;
using System.Security.Cryptography;
using System.Text;

namespace Documentation.Service.Core
{
    public class UserService
    {
        private readonly AppDbContext _db;

        public UserService(AppDbContext db)
        {
            _db = db;
        }

        public User GetById(int id)
        {
            return _db.users.First(p => p.UserID == id);
        }
        public User GetByUsername(string username)
        {
            return _db.users.First(p => p.Username == username);
        }

        public List<User> GetAll()
        {
            var users = _db.users
                .ToList();

            return users;
        }

        public void Save(User model)
        {
            _db.users.Add(model);

            _db.SaveChanges();

        }
        public void Update(User model)
        {

            _db.Update(model);
            _db.SaveChanges();

        }
        public void Delete(int id)
        {
            var model = _db.users.Find(id);
            _db.users.Remove(model);
            _db.SaveChanges();
        }

        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            string hashedInput = HashPassword(password);
            return hashedInput == hashedPassword;
        }
    }
}
