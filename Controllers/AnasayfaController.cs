using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinerKlinik.Models;

namespace VeterinerKlinik.Controllers
{
    public class AnasayfaController : Controller
    {
        private readonly VeterinerKlinikContext _context;

        public AnasayfaController(VeterinerKlinikContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}