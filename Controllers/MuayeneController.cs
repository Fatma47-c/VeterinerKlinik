using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeterinerKlinik.Models;

namespace VeterinerKlinik.Controllers
{
    public class MuayeneController : Controller
    {
        private readonly VeterinerKlinikContext _context;

        public MuayeneController(VeterinerKlinikContext context)
        {
            _context = context;
        }

        
        private bool AdminMi() =>
            HttpContext.Session.GetString("Admin") == "true";

        public async Task<IActionResult> Index()
        {
            if (!AdminMi())
                return RedirectToAction("AdminGiris", "Veteriner");

            var muayeneler = await _context.Muayeneler
                .Include(m => m.Veteriner)
                .OrderByDescending(m => m.Tarih)
                .ToListAsync();
            return View(muayeneler);
        }

        public IActionResult Create()
        {
            if (!AdminMi())
                return RedirectToAction("AdminGiris", "Veteriner");

            ViewBag.Veterinerler = new SelectList(
                _context.Veterinerler.ToList(), "Id", "Ad"
            );
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Muayene muayene)
        {
            if (!AdminMi())
                return RedirectToAction("AdminGiris", "Veteriner");

            if (ModelState.IsValid)
            {
                _context.Muayeneler.Add(muayene);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Veterinerler = new SelectList(
                _context.Veterinerler.ToList(), "Id", "Ad"
            );
            return View(muayene);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!AdminMi())
                return RedirectToAction("AdminGiris", "Veteriner");

            var muayene = await _context.Muayeneler.FindAsync(id);
            if (muayene == null) return NotFound();

            ViewBag.Veterinerler = new SelectList(
                _context.Veterinerler.ToList(), "Id", "Ad", muayene.VeterinerId
            );
            return View(muayene);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Muayene muayene)
        {
            if (!AdminMi())
                return RedirectToAction("AdminGiris", "Veteriner");

            if (id != muayene.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(muayene);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Veterinerler = new SelectList(
                _context.Veterinerler.ToList(), "Id", "Ad", muayene.VeterinerId
            );
            return View(muayene);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!AdminMi())
                return RedirectToAction("AdminGiris", "Veteriner");

            var muayene = await _context.Muayeneler
                .Include(m => m.Veteriner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (muayene == null) return NotFound();
            return View(muayene);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!AdminMi())
                return RedirectToAction("AdminGiris", "Veteriner");

            var muayene = await _context.Muayeneler.FindAsync(id);
            if (muayene != null)
            {
                _context.Muayeneler.Remove(muayene);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            if (!AdminMi())
                return RedirectToAction("AdminGiris", "Veteriner");

            var muayene = await _context.Muayeneler
                .Include(m => m.Veteriner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (muayene == null) return NotFound();
            return View(muayene);
        }
    }
}