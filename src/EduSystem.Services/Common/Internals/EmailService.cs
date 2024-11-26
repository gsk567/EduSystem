using System;
using System.Threading.Tasks;
using EduSystem.Services.Common.Contracts;
using EduSystem.Services.Common.Models;
using Essentials.Results;
using Microsoft.Extensions.DependencyInjection;

namespace EduSystem.Services.Common.Internals;

internal class EmailService : IEmailService
{
    private readonly IServiceProvider serviceProvider;

    public EmailService(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public async Task<StandardResult> SendEmailAsync(EmailModel model, string senderStrategy)
    {
        var sender = this.serviceProvider.GetKeyedService<IEmailSender>(senderStrategy);

        if (sender == null)
        {
            return StandardResult
                .UnsuccessfulResult($"There is no registered email sender strategy: '{senderStrategy}'");
        }
        
        return await sender.SendEmailAsync(model);
    }
}