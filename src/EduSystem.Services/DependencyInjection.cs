using EduSystem.Services.Common;
using EduSystem.Services.Examples;
using EduSystem.Services.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EduSystem.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddCommonServices(configuration);
        services.AddIdentityServices();

        services.AddExamplesServices(configuration);

        return services;
    }
}