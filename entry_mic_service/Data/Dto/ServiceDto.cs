namespace entry_mic_service.Data.Dto
{
    public class ServiceDto
    {
        public ServiceDto()
        {
            Args = new List<string>();
        }

        public ServiceTypeDto Type { get; set; }
        public List<string> Args { get; set; }
        public int Sequence { get; set; }
    }
}