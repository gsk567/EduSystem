using EduSystem.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace EduSystem.Services.Identity;

internal static class DependencyInjection
{
    public static IServiceCollection AddIdentityServices(
        this IServiceCollection services)
    {
        services
            .AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<EntityContext>()
            .AddDefaultTokenProviders();

        return services;
    }
}