using System.Threading.Tasks;
using EduSystem.Services.Common.Constants;
using EduSystem.Services.Common.Contracts;
using EduSystem.Services.Common.Models;
using Essentials.Results;

namespace EduSystem.Services.Identity.Extensions;

public static class EmailServiceExtensions
{
    public static async Task<StandardResult> SendResetPasswordEmailAsync(
        this IEmailService emailService,
        string email,
        string token)
    {
        return await emailService.SendEmailAsync(
            new EmailModel
            {
                Email = email,
                Subject = EduSystem.Common.Т.ResetPasswordTitle,
                Message = string.Format(EduSystem.Common.Emails.ResetPassword, token),
            },
            EmailSenderStrategies.NoOps);
    }
}