using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using EduSystem.Data;
using EduSystem.Presentation.Models;
using EduSystem.Services.Common.Contracts;
using EduSystem.Services.Identity.Constants;
using EduSystem.Services.Identity.Contracts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EduSystem.Presentation.Controllers;

public class HomeController : Controller
{
    private readonly IEmailService emailService;
    private readonly ICurrentUser currentUser;
    private readonly UserManager<ApplicationUser> userManager;
    private readonly ILogger<HomeController> logger;

    public HomeController(
        IEmailService emailService,
        ICurrentUser currentUser,
        UserManager<ApplicationUser> userManager,
        ILogger<HomeController> logger)
    {
        this.emailService = emailService;
        this.currentUser = currentUser;
        this.userManager = userManager;
        this.logger = logger;
    }

    [HttpGet("/")]
    [Authorize(DefaultPolicies.UserPolicy)]
    public async Task<IActionResult> Index()
    {
        var viewModel = new IndexViewModel
        {
            Title = "Index Title",
            Name = "PEsho",
        };

        this.ViewBag.Message = "Welcome to EduSystem!!";

        return this.View(viewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
    }
}