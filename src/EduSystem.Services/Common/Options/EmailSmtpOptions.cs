namespace EduSystem.Services.Common.Options;

public class EmailSmtpOptions
{
    public required string Host { get; set; }

    public required int Port { get; set; }

    public required bool EnableSsl { get; set; }

    public required string SenderEmail { get; set; }

    public required string SenderPassword { get; set; }
}