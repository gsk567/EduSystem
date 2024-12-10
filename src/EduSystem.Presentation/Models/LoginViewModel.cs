using System.ComponentModel.DataAnnotations;

namespace EduSystem.Presentation.Models;

public class LoginViewModel
{
    [Required(
        ErrorMessageResourceType = typeof(Common.Т),
        ErrorMessageResourceName = "EmailIsRequiredErrorMessage")]
    public string? Email { get; set; }

    [Required(
        ErrorMessageResourceType = typeof(Common.Т),
        ErrorMessageResourceName = "PasswordIsRequiredErrorMessage")]
    public string? Password { get; set; }

    public bool RememberMe { get; set; }
}