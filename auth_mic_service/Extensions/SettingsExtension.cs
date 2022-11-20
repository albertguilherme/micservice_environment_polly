using auth_mic_service.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace auth_mic_service.Extensions
{
    public static class SettingsExtension
    {
        public static WebApplicationBuilder ConfigureSettings(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

            return builder;
        }
    }

    public class JwtSettings
    {
        public string Secret { get; set; }
    }
}
