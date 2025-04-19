using Microsoft.AspNetCore.Mvc;
using Heaven.Models;
using Heaven.Models.Account;
using Heaven.Services;

namespace Heaven.Controllers
{
    public class AccountController : Controller
    {

        private readonly AccountService _service;

        public AccountController()
        {
            _service = new AccountService();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new User
            {
                FullName = model.FullName,
                Email = model.Email,
                PasswordHash = model.Password,
                PhoneNumber = model.PhoneNumber,
                Bio = model.Bio
            };

            _service.CreateUser(user);

            return RedirectToAction("Login");
        }

    
    }
}