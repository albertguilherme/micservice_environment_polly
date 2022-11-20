using auth_mic_service.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureDatabase();
builder.ConfigureRepository();
builder.ConfigureService();
builder.ConfigureSettings();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.SeedDatabase();

app.Run();
