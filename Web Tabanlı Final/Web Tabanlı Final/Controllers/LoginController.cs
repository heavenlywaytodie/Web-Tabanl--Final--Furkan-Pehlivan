using Microsoft.AspNetCore.Mvc;
using Web_Tabanlı_Final.Data;
using Web_Tabanlı_Final.Models;

namespace Web_Tabanlı_Final.Controllers
{
    public class LoginController : Controller
    {
        private readonly CineCriticDbContext _context;

        public LoginController(CineCriticDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("~/Views/Home/Login.cshtml");
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.KullanıcıAdı == model.KullanıcıAdı && u.Sıfre == model.Sıfre);
                if (user != null)
                {
                    TempData["SuccessMessage"] = "Başarıyla giriş yaptınız!";
                    return RedirectToAction("Ana", "Home");
                }
                else
                {
                    ViewBag.Message = "Kullanıcı adı veya şifre yanlış.";
                }
            }
            return View("~/Views/Home/Login.cshtml");
        }
    }
}

