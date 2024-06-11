using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using question_app.Constants;
using question_app.Models;

namespace question_app.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewData["Title"] = ViewConstants.HOME_TITLE;
        ViewData["HomeQuestionsListTitle"] = ViewConstants.HOME_QUESTION_LIST_TITLE;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Question()
    {
        ViewData["Title"] = ViewConstants.QUESTION_TITLE;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
