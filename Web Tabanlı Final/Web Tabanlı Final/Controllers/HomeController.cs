using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Web_Tabanlı_Final.Data; // DbContext için
using Web_Tabanlı_Final.Models; // Film modeli için
using System.Linq;


namespace Web_Tabanlı_Final.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CineCriticDbContext _context;  // DbContext'i ekledik

        public HomeController(ILogger<HomeController> logger, CineCriticDbContext context)
        {
            _logger = logger;
            _context = context;  // DbContext'i constructor üzerinden alıyoruz
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Ana()
        {
            var filmler = await _context.Filmler.ToListAsync();
            if (filmler == null || !filmler.Any())
            {
                filmler = new List<Film>(); // Eğer veri yoksa boş liste döndürüyoruz
            }

            return View(filmler); // Filmleri View'a gönderiyoruz
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> Film(int id)
        {
            var film = await _context.Filmler
                                     .Include(f => f.Yorumlar) // Yorumları dahil ediyoruz
                                     .FirstOrDefaultAsync(f => f.FilmID == id);

            if (film == null)
            {
                return NotFound();
            }
            return View(film);
        }



        [HttpPost]
        public async Task<IActionResult> YorumYap(int FilmID, string KullanıcıAdı, string Metin)
        {
            if (string.IsNullOrWhiteSpace(Metin) || string.IsNullOrWhiteSpace(KullanıcıAdı))
            {
                return RedirectToAction("Film", new { id = FilmID }); // Boş veri gönderilirse sayfaya dön
            }

            var yeniYorum = new Yorum
            {
                FilmID = FilmID,
                KullanıcıAdı = KullanıcıAdı,
                Metin = Metin
            };

            _context.Yorumlar.Add(yeniYorum);
            await _context.SaveChangesAsync();

            return RedirectToAction("Film", new { id = FilmID }); // Yorumu kaydedip film sayfasına dön
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
}

