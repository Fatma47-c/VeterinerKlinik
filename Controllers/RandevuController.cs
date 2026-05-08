using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinerKlinik.Models;

namespace VeterinerKlinik.Controllers
{
    public class RandevuController : Controller
    {
        private readonly VeterinerKlinikContext _context;

        public RandevuController(VeterinerKlinikContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var randevular = await _context.Randevular
                .Include(r => r.Veteriner)
                .OrderBy(r => r.Tarih)
                .ToListAsync();
            return View(randevular);
        }

        public IActionResult Create()
        {
            ViewBag.Veterinerler = _context.Veterinerler.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Randevu randevu)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Veterinerler = _context.Veterinerler.ToList();
                return View(randevu);
            }

            var hastaliklar = await _context.Hastaliklar.ToListAsync();
            if (hastaliklar.Any())
            {
                var rastgele = new Random();
                var secilen = hastaliklar[rastgele.Next(hastaliklar.Count)];
                randevu.Hastalik = secilen.Ad;
                randevu.Tedavi = secilen.Tedavi;
                randevu.Ucret = secilen.Ucret;
            }

            _context.Randevular.Add(randevu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var randevu = await _context.Randevular
                .Include(r => r.Veteriner)
                .FirstOrDefaultAsync(r => r.Id == id);
            if (randevu == null) return NotFound();
            return View(randevu);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var randevu = await _context.Randevular.FindAsync(id);
            if (randevu != null)
            {
                _context.Randevular.Remove(randevu);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}