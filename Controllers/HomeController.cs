using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using imagenDental.Models;

namespace imagenDental.Controllers;

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

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet("Dashboard")]
    public IActionResult Dashboard()
    {
        return View();
    }

    [HttpGet("Clinico")]
    public IActionResult Clinico()
    {
        return View();
    }
    [HttpGet("Operaciones")]
    public IActionResult Operaciones()
    {
        return View();
    }
    [HttpGet("Calidad")]
    public IActionResult Calidad()
    {
        return View();
    }
    [HttpGet("RH")]
    public IActionResult RH()
    {
        return View();
    }
    [HttpGet("Sistemas")]
    public IActionResult Sistemas()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
