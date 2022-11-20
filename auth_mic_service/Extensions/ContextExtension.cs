using auth_mic_service.Data;
using Microsoft.EntityFrameworkCore;

namespace auth_mic_service.Extensions
{
    public static class ContextExtension
    {
        public static WebApplicationBuilder ConfigureDatabase(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<Context>(opt => {
                opt.UseInMemoryDatabase("InMem");
            });

            return builder;
        }


        public static void SeedDatabase(this WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var ctx = scope.ServiceProvider.GetRequiredService<Context>();

            if (ctx == null)
                throw new NullReferenceException("ctx service not found");

            if(!ctx.Users.Any())
            {
                ctx.Users.Add(new Data.Model.User()
                {
                    Email = "sheldon@caltech.edu",
                    FirstName = "Sheldon",
                    LastName = "Cooper",
                    Password = "train".ToMd5(),
                    Username = "sheldon",
                    Roles = new List<Data.Model.Role>()
                    {
                        new Data.Model.Role()
                        {
                            Description = "NobelLaureate",
                            Acronyms = "NL"
                        }
                    },
                });

                ctx.SaveChanges();
            }
        }
    }

}
