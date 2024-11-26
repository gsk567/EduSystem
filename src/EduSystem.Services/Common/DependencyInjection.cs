using EduSystem.Services.Common.Constants;
using EduSystem.Services.Common.Contracts;
using EduSystem.Services.Common.Internals;
using EduSystem.Services.Common.Internals.EmailSenders;
using EduSystem.Services.Common.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EduSystem.Services.Common;

public static class DependencyInjection
{
    public static IServiceCollection AddCommonServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        if (configuration.GetSection("Emails:Smtp").GetValue<bool>("Enabled"))
        {
            services.Configure<EmailSmtpOptions>(configuration.GetSection("Emails:Smtp"));
            services.AddKeyedScoped<IEmailSender, SmtpSender>(EmailSenderStrategies.Smtp);
        }

        if (configuration.GetSection("Emails:SendGrid").GetValue<bool>("Enabled"))
        {
            services.Configure<EmailSendGridOptions>(configuration.GetSection("Emails:SendGrid"));
            services.AddKeyedScoped<IEmailSender, SendGridSender>(EmailSenderStrategies.SendGrid);
        }
        
        services.AddScoped<IEmailService, EmailService>();
        services.AddKeyedScoped<IEmailSender, NoOpsSender>(EmailSenderStrategies.NoOps);
        
        return services;
    }
}