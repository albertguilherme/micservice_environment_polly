using entry_mic_service.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder
    .ConfigureDatabase()
    .ConfigureJwt()
    .ConfigureSettings();

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

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.SeedDatabase();

app.Run();
