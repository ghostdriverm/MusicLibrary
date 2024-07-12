using Microsoft.Extensions.DependencyInjection;

namespace MusicLibrary.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddAplication(this IServiceCollection services)
    {
        var applcationAssembly = typeof(ServiceCollectionExtension).Assembly;
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applcationAssembly));

        services.AddAutoMapper(applcationAssembly);

    }
}
