using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinerKlinik.Models;

namespace VeterinerKlinik.Controllers
{
    public class HayvanController : Controller
    {
        private readonly VeterinerKlinikContext _context;

        public HayvanController(VeterinerKlinikContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var hayvanlar = await _context.Hayvanlar.ToListAsync();
            return View(hayvanlar);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string kategori, string ad, int yas,
            string tur, string? cins, string musteriAdi)
        {
            Hayvan hayvan = kategori switch
            {
                "Evcil" => new EvcilHayvan(),
                "Çiftlik" => new CiftlikHayvani(),
                "Egzotik" => new EgzotikHayvan(),
                _ => throw new Exception("Geçersiz kategori")
            };

            hayvan.Ad = ad;
            hayvan.Yas = yas;
            hayvan.Kategori = kategori;
            hayvan.Tur = tur;
            hayvan.Cins = cins;
            hayvan.MusteriAdi = musteriAdi;

            _context.Hayvanlar.Add(hayvan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var hayvan = await _context.Hayvanlar.FindAsync(id);
            if (hayvan == null) return NotFound();
            return View(hayvan);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var hayvan = await _context.Hayvanlar.FindAsync(id);
            if (hayvan == null) return NotFound();
            return View(hayvan);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, string ad, int yas,
            string tur, string? cins, string musteriAdi)
        {
            var hayvan = await _context.Hayvanlar.FindAsync(id);
            if (hayvan == null) return NotFound();

            hayvan.Ad = ad;
            hayvan.Yas = yas;
            hayvan.Tur = tur;
            hayvan.Cins = cins;
            hayvan.MusteriAdi = musteriAdi;

            _context.Update(hayvan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var hayvan = await _context.Hayvanlar.FindAsync(id);
            if (hayvan == null) return NotFound();
            return View(hayvan);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hayvan = await _context.Hayvanlar.FindAsync(id);
            if (hayvan != null)
            {
                _context.Hayvanlar.Remove(hayvan);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}