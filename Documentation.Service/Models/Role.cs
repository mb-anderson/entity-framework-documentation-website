namespace Documentation.Service.Models
{
    public class Role
    {
        public int RoleID { get; set; }
        public string? RoleName { get; set; }

        public ICollection<UsersRoles> UserRoles { get; set; }
    }
}
