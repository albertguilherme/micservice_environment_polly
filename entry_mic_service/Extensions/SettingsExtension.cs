namespace entry_mic_service.Extensions
{
    public static class SettingsExtension
    {
        public static WebApplicationBuilder ConfigureSettings(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<MongoServiceDatabaseSettings>(builder.Configuration.GetSection("ServiceDatabase"));

            return builder;
        }
    }

    public class MongoServiceDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
