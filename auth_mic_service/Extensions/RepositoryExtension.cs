using auth_mic_service.Data;
using auth_mic_service.Repository.Impl;
using auth_mic_service.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace auth_mic_service.Extensions
{
    public static class RepositoryExtension
    {
        public static IServiceCollection ConfigureRepository(this IServiceCollection service)
        {
            service.AddScoped<IUserRepository, UserRepository>();

            return service;
        }
    }
}
