using System.Threading.Tasks;
using EduSystem.Services.Common.Models;
using Essentials.Results;

namespace EduSystem.Services.Common.Contracts;

internal interface IEmailSender
{
    Task<StandardResult> SendEmailAsync(EmailModel model);
}