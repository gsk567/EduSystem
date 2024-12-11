using System.ComponentModel.DataAnnotations;

namespace EduSystem.Presentation.Models;

public class LoginViewModel
{
    [Required(
        ErrorMessageResourceType = typeof(Common.Т),
        ErrorMessageResourceName = "EmailIsRequiredErrorMessage")]
    [EmailAddress(
        ErrorMessageResourceType = typeof(Common.Т),
        ErrorMessageResourceName = "EmailIsInvalidErrorMessage")]
    public string? Email { get; set; }

    [Required(
        ErrorMessageResourceType = typeof(Common.Т),
        ErrorMessageResourceName = "PasswordIsRequiredErrorMessage")]
    public string? Password { get; set; }

    public bool RememberMe { get; set; }
}