using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


[Route("Home")]
public class HomeController : Controller
{
    [HttpGet]
    [Route("")]
    [Route("Index")]
    public IActionResult Index()
    {
        return View(); // Views/Home/Index.cshtml
    }

    [HttpGet]
    [Route("SignUp")]
    public IActionResult SignUp()
    {
        return View(); // Views/Home/CreateAccount.cshtml
    }
}
