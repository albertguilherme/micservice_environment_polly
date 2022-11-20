namespace entry_mic_service.Data.Model
{
    public class Result : Base
    {
        public EStatus Status { get; set; }
        public string Message { get; set; }
        public string ServiceResultId { get; set; }
    }
}