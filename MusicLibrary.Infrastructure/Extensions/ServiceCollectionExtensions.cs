using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicLibrary.Infrastructure.Persistence;
using MusicLibrary.Infrastructure.Seeders;

namespace MusicLibrary.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructe(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MusicLibraryDb");
        services.AddDbContext<MusicLibraryDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<IMusicLibrarySeeder, MusicLibrarySeeder>();
    }
}
