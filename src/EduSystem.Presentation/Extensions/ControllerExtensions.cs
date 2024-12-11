using Microsoft.AspNetCore.Mvc;

namespace EduSystem.Presentation.Extensions;

public static class ControllerExtensions
{
    public static bool IsUserAuthenticated(this Controller controller) =>
        controller.User?.Identity?.IsAuthenticated ?? false;

    public static IActionResult RedirectToDefault(this Controller controller) =>
        controller.RedirectToAction("Index", "Home");
}