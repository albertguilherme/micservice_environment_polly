namespace auth_mic_service.Data.Dto
{
    public class TokenDto
    {
        public string Type { get; set; } = "Bearer";
        public string Value { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
