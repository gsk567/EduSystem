using EduSystem.Services.Examples.ExternalApi;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EduSystem.Services.Examples;

public static class DependencyInjection
{
    public static IServiceCollection AddExamplesServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddExamplesExternalApi(configuration);

        return services;
    }
}