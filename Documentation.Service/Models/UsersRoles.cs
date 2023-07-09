namespace Documentation.Service.Models
{
    public class UsersRoles
    {
        public int Users_roles_ID { get; set; }
        public int User_id { get; set; }
        public User User { get; set; }
        public int Role_id { get; set; }
        public Role Role { get; set; }
    }
}
