using System.Diagnostics;
using System.Net.Http.Headers;

using Microsoft.AspNetCore.Mvc;
using Mvc.Models;
using Newtonsoft.Json;
using Service.Models;

namespace Mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult IndexAsync()
    {
        
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

