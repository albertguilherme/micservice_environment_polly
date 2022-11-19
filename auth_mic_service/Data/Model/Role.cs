namespace auth_mic_service.Data.Model
{
    public class Role : Base
    {
        public Role()
        {
            Users = new HashSet<User>();
        }
            
        public string Description { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}