using auth_mic_service.Data;
using auth_mic_service.Repository.Impl;
using auth_mic_service.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace auth_mic_service.Extensions
{
    public static class RepositoryExtension
    {
        public static WebApplicationBuilder ConfigureRepository(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ITokenRepository, TokenRepository>();

            return builder;
        }
    }
}
