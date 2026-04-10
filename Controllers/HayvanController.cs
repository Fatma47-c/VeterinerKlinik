using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeterinerKlinik.Data;
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
            var hayvanlar = await _context.Hayvanlar
                .Include(h => h.Musteri)
                .ToListAsync();
            return View(hayvanlar);
        }


        public IActionResult Create()
        {
            ViewBag.Musteriler = new SelectList(_context.Musteriler, "Id", "Ad");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string hayvanTuru, string ad,
            int yas, int musteriId, string irk, string boyut,
            bool tuyluMu, string turAdi, bool konusabilirMi)
        {
            Hayvan hayvan = hayvanTuru switch
            {
                "Kopek" => new Kopek { Irk = irk, Boyut = boyut },
                _ => throw new Exception("Geçersiz tür")
            };

            hayvan.Ad = ad;
            hayvan.Yas = yas;
            hayvan.MusteriId = musteriId;

            _context.Hayvanlar.Add(hayvan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
        public async Task<IActionResult> Details(int id)
        {
            var hayvan = await _context.Hayvanlar
                .Include(h => h.Musteri)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (hayvan == null) return NotFound();
            return View(hayvan);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var hayvan = await _context.Hayvanlar.FindAsync(id);
            if (hayvan == null) return NotFound();
            ViewBag.Musteriler = new SelectList(_context.Musteriler, "Id", "Ad", hayvan.MusteriId);
            return View(hayvan);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, string ad, int yas,
            int musteriId, string irk, string boyut,
            bool tuyluMu, string turAdi, bool konusabilirMi)
        {
            var hayvan = await _context.Hayvanlar.FindAsync(id);
            if (hayvan == null) return NotFound();

            hayvan.Ad = ad;
            hayvan.Yas = yas;
            hayvan.MusteriId = musteriId;

            if (hayvan is Kopek kopek) { kopek.Irk = irk; kopek.Boyut = boyut; }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var hayvan = await _context.Hayvanlar
                .Include(h => h.Musteri)
                .FirstOrDefaultAsync(h => h.Id == id);
            if (hayvan == null) return NotFound();
            return View(hayvan);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hayvan = await _context.Hayvanlar.FindAsync(id);
            if (hayvan == null) return NotFound();

            _context.Hayvanlar.Remove(hayvan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
