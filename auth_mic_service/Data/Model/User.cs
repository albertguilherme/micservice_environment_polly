using System.ComponentModel.DataAnnotations.Schema;

namespace auth_mic_service.Data.Model
{
    public class User : Base
    {
        public User()
        {
            Roles = new HashSet<Role>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped] public string Name => $"{FirstName?.Trim()} {LastName?.Trim()}";
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
