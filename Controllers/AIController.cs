using Microsoft.AspNetCore.Mvc;

namespace VeterinerKlinik.Controllers
{
    [Route("AI")]
    public class AIController : Controller
    {
        private readonly VeterinerAsistanServisi _asistanServisi;

        // Yapay zeka servisini buraya bağlıyoruz
        public AIController(VeterinerAsistanServisi asistanServisi)
        {
            _asistanServisi = asistanServisi;
        }

        // Sayfayı ekrana getirir
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("SoruSor")] // Yolu garantiye alıyoruz
        public async Task<JsonResult> SoruSor([FromForm] string mesaj)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(mesaj))
                    return Json(new { cevap = "Boş mesaj gönderilemez." });

                // Gemini'den cevabı alıyoruz
                string asistanYaniti = await _asistanServisi.SoruSor(mesaj);

                // JSON dönerken isimlendirmeyi zorla küçük harf yapıyoruz
                return Json(new { cevap = asistanYaniti });
            }
            catch (Exception ex)
            {
                // Hata olursa sebebini ekrana yazdırır
                return Json(new { cevap = "Hata: " + ex.Message });
            }
        }
    }
    }
