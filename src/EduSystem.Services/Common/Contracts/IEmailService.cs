using System.Threading.Tasks;
using EduSystem.Services.Common.Models;
using Essentials.Results;

namespace EduSystem.Services.Common.Contracts;

public interface IEmailService
{
    Task<StandardResult> SendEmailAsync(EmailModel model, string senderStrategy);
}