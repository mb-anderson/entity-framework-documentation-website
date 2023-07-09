using Microsoft.EntityFrameworkCore;
using Documentation.Service.Models;

namespace Documentation.Service.Veritabani
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> categories { get; set; }
        public DbSet<Dokuman> documents { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<UsersRoles> users_roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UsersRoles>()
                .HasKey(ur => new { ur.User_id, ur.Role_id });

            modelBuilder.Entity<UsersRoles>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.User_id);

            modelBuilder.Entity<UsersRoles>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.Role_id);



            base.OnModelCreating(modelBuilder);
        }


    }
}
