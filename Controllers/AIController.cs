using Microsoft.AspNetCore.Mvc;

namespace VeterinerKlinik.Controllers
{
    [Route("AI")]
    public class AIController : Controller
    {
        private readonly VeterinerAsistanServisi _asistanServisi;

        public AIController(VeterinerAsistanServisi asistanServisi)
        {
            _asistanServisi = asistanServisi;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("SoruSor")]
        public async Task<JsonResult> SoruSor([FromForm] string mesaj)
        {
            if (string.IsNullOrWhiteSpace(mesaj))
                return Json(new { cevap = "Boş mesaj gönderilemez." });

            try
            {
                string yanit = await _asistanServisi.SoruSor(mesaj);
                return Json(new { cevap = yanit });
            }
            catch (Exception ex)
            {
                return Json(new { cevap = "Hata: " + ex.Message });
            }
        }
    }
}