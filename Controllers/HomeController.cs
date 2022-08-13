using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebProje2.Models;

namespace WebProje2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult cart()
    {
        return View();
    }

    public IActionResult checkout()
    {
        return View();
    }

    public IActionResult shop()
    {
        return View();
    }

    public IActionResult productdetails()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
