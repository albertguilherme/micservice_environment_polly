using auth_mic_service.Data;
using auth_mic_service.Repository.Impl;
using auth_mic_service.Repository.Interface;
using auth_mic_service.Services.Impl;
using auth_mic_service.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace auth_mic_service.Extensions
{
    public static class ServiceExtension
    {
        public static WebApplicationBuilder ConfigureService(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ITokenService, TokenService>();

            return builder;
        }
    }
}
