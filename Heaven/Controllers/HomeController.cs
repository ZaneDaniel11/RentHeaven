using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Heaven.Models;

namespace Heaven.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly RentContext _context;
    public HomeController(ILogger<HomeController> logger, RentContext context)

    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

}
