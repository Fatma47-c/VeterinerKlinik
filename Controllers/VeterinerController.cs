using Microsoft.AspNetCore.Mvc;
using VeterinerKlinik.Models;
using Microsoft.EntityFrameworkCore;

namespace VeterinerKlinik.Controllers
{
    public class VeterinerController : Controller
    {
        private readonly VeterinerKlinikContext _context;

        public VeterinerController(VeterinerKlinikContext context)
        {
            _context = context;
        }

        // LİSTELE
        public async Task<IActionResult> Index()
        {
            var veterinerler = await _context.Veterinerler.ToListAsync();
            return View(veterinerler);
        }

        // CREATE - FORM
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Admin") != "true")
                return RedirectToAction("AdminGiris");
            return View();
        }

        // CREATE - KAYDET
        [HttpPost]
        public async Task<IActionResult> Create(Veteriner veteriner)
        {
            if (HttpContext.Session.GetString("Admin") != "true")
                return RedirectToAction("AdminGiris");

            if (ModelState.IsValid)
            {
                _context.Veterinerler.Add(veteriner);
                await _context.SaveChangesAsync();
                return RedirectToAction("AdminPanel");
            }
            return View(veteriner);
        }

        // EDIT - FORM
        public async Task<IActionResult> Edit(int id)
        {
            if (HttpContext.Session.GetString("Admin") != "true")
                return RedirectToAction("AdminGiris");

            var veteriner = await _context.Veterinerler.FindAsync(id);
            if (veteriner == null)
                return NotFound();
            return View(veteriner);
        }

        // EDIT - KAYDET
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Veteriner veteriner)
        {
            if (HttpContext.Session.GetString("Admin") != "true")
                return RedirectToAction("AdminGiris");

            if (id != veteriner.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Veterinerler.Update(veteriner);
                await _context.SaveChangesAsync();
                return RedirectToAction("AdminPanel");
            }
            return View(veteriner);
        }

        // DELETE
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (HttpContext.Session.GetString("Admin") != "true")
                return RedirectToAction("AdminGiris");

            var veteriner = await _context.Veterinerler.FindAsync(id);
            if (veteriner == null)
                return NotFound();

            _context.Veterinerler.Remove(veteriner);
            await _context.SaveChangesAsync();
            return RedirectToAction("AdminPanel");
        }

        // ADMIN GİRİŞ SAYFASI
        public IActionResult AdminGiris()
        {
            return View();
        }

        // ADMIN GİRİŞ KONTROL
        [HttpPost]
        public IActionResult AdminGiris(string sifre)
        {
            if (sifre == "admin")
            {
                HttpContext.Session.SetString("Admin", "true");
                return RedirectToAction("AdminPanel");
            }
            ViewBag.Hata = "Şifre yanlış!";
            return View();
        }

        // ÇIKIŞ
        public IActionResult AdminCikis()
        {
            HttpContext.Session.Remove("Admin");
            return RedirectToAction("Index");
        }

        // ADMIN PANEL
        public async Task<IActionResult> AdminPanel()
        {
            if (HttpContext.Session.GetString("Admin") != "true")
                return RedirectToAction("AdminGiris");

            var veterinerler = await _context.Veterinerler.ToListAsync();
            return View(veterinerler);
        }
    }
}