using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using EduSystem.Services.Common.Models;
using EduSystem.Services.Common.Options;
using Essentials.Results;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using IEmailSender = EduSystem.Services.Common.Contracts.IEmailSender;

namespace EduSystem.Services.Common.Internals.EmailSenders;

internal class SmtpSender : IEmailSender
{
    private readonly IOptions<EmailSmtpOptions> optionsAccessor;
    private readonly ILogger<SmtpSender> logger;

    public SmtpSender(
        IOptions<EmailSmtpOptions> optionsAccessor,
        ILogger<SmtpSender> logger)
    {
        this.optionsAccessor = optionsAccessor;
        this.logger = logger;
    }
    
    public async Task<StandardResult> SendEmailAsync(EmailModel model)
    {
        try
        {
            var options = this.optionsAccessor.Value;
            using var client = new SmtpClient(options.Host, options.Port);
            client.Credentials = new NetworkCredential(options.SenderEmail, options.SenderPassword);
            client.EnableSsl = options.EnableSsl;

            var mailMessage = new MailMessage
            {
                From = new MailAddress(options.SenderEmail),
                Subject = model.Subject,
                Body = model.Message,
                IsBodyHtml = false
            };

            mailMessage.To.Add(model.Email);

            await client.SendMailAsync(mailMessage);

            return StandardResult.SuccessfulResult();
        }
        catch (Exception e)
        {
            var message = "An error occured while sending email via SMTP.";
            this.logger.LogError(e, message);
            return StandardResult.UnsuccessfulResult(message);
        }
    }
}