namespace entry_mic_service.Data.Model
{
    public class Service : Base
    {
        public Service()
        {
            Args = new List<string>();
        }

        public string TypeId { get; set; }
        public string Description { get; set; }
        public string TopicToPublish { get; set; }
        public List<string> Args { get; set; }
    }
}
