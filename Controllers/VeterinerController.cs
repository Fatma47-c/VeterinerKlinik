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

        public async Task<IActionResult> Index()
        {
            var veterinerler = await _context.Veterinerler.ToListAsync();
            return View(veterinerler);
        }
    }
}