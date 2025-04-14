using System;
using Facebook.Models;
using Facebook.Models.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Facebook.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly FacebookContext _context;

        public AccountController(ILogger<AccountController> logger, FacebookContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            Console.WriteLine(">>> Register POST HIT <<<");

            if (ModelState.IsValid)

            {
                foreach (var modelState in ModelState)
                {
                    foreach (var error in modelState.Value.Errors)
                    {
                        Console.WriteLine($"Field: {modelState.Key}, Error: {error.ErrorMessage}");
                    }
                }
                Console.WriteLine(">>> Model is valid <<<");

                // Check if email already exists
                if (_context.Users.Any(u => u.Email == model.Email))
                {
                    ModelState.AddModelError("Email", "Email is already registered.");
                    return View(model);
                }

                var user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password),
                    Gender = model.Gender,
                    BirthDate = model.BirthDate,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                Console.WriteLine(">>> User saved <<<");

                return RedirectToAction("Index", "Account");
            }

            Console.WriteLine(">>> Model is NOT valid <<<");
            return View(model);
        }


        
        [HttpPost("Login")]
        public IActionResult Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                var userEmail = _context.Users.FirstOrDefault(u => u.Email == model.Email);
                if (userEmail != null && BCrypt.Net.BCrypt.Verify(model.Password, userEmail.PasswordHash))
                {
                    Console.WriteLine(">>> Login successful <<<");
                    // You can add session or claims auth here
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid email or password.");
                    Console.WriteLine(">>> Login failed <<<");

                }

            }

            return View(model);
        }

    }

}