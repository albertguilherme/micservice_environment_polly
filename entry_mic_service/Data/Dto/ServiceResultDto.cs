namespace entry_mic_service.Data.Dto
{
    public class ServiceResultDto
    {
        public ServiceResultDto()
        {
            Results = new List<ResultDto>();
        }

        public string Id { get; set; }
        public ServiceDto Service { get; set; }
        public List<ResultDto> Results { get; set; }
    }
}