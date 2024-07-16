using MusicLibrary.Application.Extensions;
using MusicLibrary.Infrastructure.Extensions;
using MusicLibrary.Infrastructure.Seeders;
using MusicLibrary.WebAPI.Extensions;
using MusicLibrary.WebAPI.Services;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    //builder.Services.AddControllers();
    builder.AddPresentation();
    builder.Services.AddAplication();

    builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();

    builder.Services.AddInfrastructe(builder.Configuration);

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    var scope = app.Services.CreateScope();
    var seeder = scope.ServiceProvider.GetRequiredService<IMusicLibrarySeeder>();

    await seeder.Seed();

    app.UseDefaultFiles();
    app.UseStaticFiles();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    //app.UseAuthorization();

    app.MapControllers();

    app.MapFallbackToFile("/index.html");

    app.Run();
}
catch (Exception ex)
{
    Console.Write(ex.Message, "Application startup failed");
}
finally
{
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
}