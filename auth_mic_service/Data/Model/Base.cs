using System.ComponentModel.DataAnnotations;

namespace auth_mic_service.Data.Model
{
    public abstract class Base
    {
        [Key] public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdate { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
