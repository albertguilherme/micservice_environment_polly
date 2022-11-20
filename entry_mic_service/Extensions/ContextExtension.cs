using entry_mic_service.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace entry_mic_service.Extensions
{
    public static class ContextExtension
    {
        public static WebApplicationBuilder ConfigureDatabase(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<Context>();

            return builder;
        }


        public static void SeedDatabase(this WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var ctx = scope.ServiceProvider.GetRequiredService<Context>();

            if (ctx == null)
                throw new NullReferenceException("ctx service not found");

            var c = ctx.ServiceTypes.CountDocuments(new BsonDocument());

        }
    }

}
