namespace auth_mic_service.Data.Model
{
    public class Token : Base
    {
        public virtual User User { get; set; }
        public string Value { get; set; }
    }
}
