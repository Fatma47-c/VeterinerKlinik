using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinerKlinik.Models;

namespace VeterinerKlinik.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly VeterinerKlinikContext _context;

        public HomeController(ILogger<HomeController> logger, VeterinerKlinikContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Admin") != "true")
                return RedirectToAction("AdminGiris", "Veteriner");

            var bugun = DateTime.Today;
            var model = new DashboardViewModel
            {
                ToplamMuayeneSayisi = await _context.Muayeneler.CountAsync(),

                ToplamRandevuSayisi = await _context.Randevular.CountAsync(),
                ToplamVeterinerSayisi = await _context.Veterinerler.CountAsync(),
                ToplamMusteriSayisi = await _context.Randevular
                    .Select(r => r.MusteriAdi)
                    .Distinct()
                    .CountAsync(),
                MuayeneToplamGelir = await _context.Muayeneler
                    .SumAsync(m => m.Ucret),
                ToplamGelir = await _context.Randevular
                    .Where(r => r.Ucret != null)
                    .SumAsync(r => r.Ucret ?? 0),
                BugunkuGelir = await _context.Randevular
                    .Where(r => r.Tarih.Date == bugun && r.Ucret != null)
                    .SumAsync(r => r.Ucret ?? 0),
                BugunkuRandevuSayisi = await _context.Randevular
                    .Where(r => r.Tarih.Date == bugun)
                    .CountAsync(),
                BugunkuRandevular = await _context.Randevular
                    .Include(r => r.Veteriner)
                    .Where(r => r.Tarih.Date == bugun)
                    .OrderBy(r => r.Tarih)
                    .ToListAsync(),
                SonRandevular = await _context.Randevular
                    .Include(r => r.Veteriner)
                    .OrderByDescending(r => r.Tarih)
                    .Take(5)
                    .ToListAsync(),
                Veterinerler = await _context.Veterinerler
                    .ToListAsync(),
                SonMuayeneler = await _context.Muayeneler
                    .Include(m => m.Veteriner)
                    .OrderByDescending(m => m.Tarih)
                    .Take(5)
                    .ToListAsync(),
            };
            return View(model);
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