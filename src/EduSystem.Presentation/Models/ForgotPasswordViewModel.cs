using System.ComponentModel.DataAnnotations;

namespace EduSystem.Presentation.Models;

public class ForgotPasswordViewModel
{
    [Required(
        ErrorMessageResourceType = typeof(Common.Т),
        ErrorMessageResourceName = "EmailIsRequiredErrorMessage")]
    [EmailAddress(
        ErrorMessageResourceType = typeof(Common.Т),
        ErrorMessageResourceName = "EmailIsInvalidErrorMessage")]
    public string? Email { get; set; }
}