using Microsoft.AspNetCore.Mvc;
using Web_Tabanlı_Final.Data;
using Web_Tabanlı_Final.Models;

namespace Web_Tabanlı_Final.Controllers
{
    public class RegisterController : Controller
    {
        private readonly CineCriticDbContext _context;

        public RegisterController(CineCriticDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();

                // Üye oldunuz mesajını TempData'ya ekleyin
                TempData["SuccessMessage"] = "Başarıyla Üye oldunuz!";

                return RedirectToAction("Ana", "Home");
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            return View(user);
        }
    }
}







