namespace auth_mic_service.Data.Model
{
    public class Token : Base
    {
        public virtual User User { get; set; }
        public string Value { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
