using System.Diagnostics;
using System.Threading.Tasks;
using EduSystem.Presentation.Models;
using EduSystem.Services.Common.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EduSystem.Presentation.Controllers;

public class HomeController : Controller
{
    private readonly IEmailService emailService;
    private readonly ILogger<HomeController> logger;

    public HomeController(
        IEmailService emailService,
        ILogger<HomeController> logger)
    {
        this.emailService = emailService;
        this.logger = logger;
    }

    [HttpGet("/")]
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