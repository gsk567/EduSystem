using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EduSystem.Services.Examples.ExternalApi;

public static class DependencyInjection
{
    public static IServiceCollection AddExamplesExternalApi(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<
            IReqResService, ReqResService>();

        services.AddHttpClient("ReqRes", client =>
        {
            client.BaseAddress = new Uri("https://reqres.in/");
            client.DefaultRequestHeaders.Add("X-Access-Token", configuration["ReqResToken"]);
        });

        return services;
    }
}