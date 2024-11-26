namespace EduSystem.Services.Common.Models;

public class EmailModel
{
    public required string Email { get; set; }

    public required string Subject { get; set; }
    
    public required string Message { get; set; }
}