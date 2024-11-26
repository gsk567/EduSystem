namespace EduSystem.Services.Common.Options;

public class EmailSendGridOptions
{
    public required string ApiKey { get; set; }

    public required string Email { get; set; }

    public required string Name { get; set; }
}