using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinerKlinik.Models;

namespace VeterinerKlinik.Controllers
{
    public class RandevuController : Controller
    {
        private readonly VeterinerKlinikContext _context;

        private static readonly Dictionary<string, List<(string Hastalik, string Tedavi, decimal Ucret)>> _hastaliklar = new()
        {
            { "Kedi",   new() {
                ("Üst Solunum Yolu Enfeksiyonu", "Antibiyotik ve buhar tedavisi", 1850),
                ("Kulak Uyuzu", "Kulak damlası ve temizlik", 1200),
                ("FIV (Kedi AIDS'i)", "Antiviral ilaç tedavisi", 3500) } },
            { "Köpek",  new() {
                ("Parvovirus", "Serum ve destekleyici tedavi", 4500),
                ("Deri Alerjisi", "Kortikosteroid ve özel diyet", 2800),
                ("Distemper", "Antiviral ve nörolojik destek", 5200) } },
            { "Kuş",    new() {
                ("Tüy Dökülmesi", "Vitamin takviyesi ve ışık tedavisi", 1400),
                ("Sindirim Bozukluğu", "Probiyotik ve diyet değişikliği", 1100),
                ("Psittakoz", "Doksisiklin antibiyotik tedavisi", 2600) } },
            { "Tavuk",  new() {
                ("Newcastle Hastalığı", "Aşılama ve karantina", 2200),
                ("Koksidioz", "Koksidiyostat ilaç tedavisi", 1800),
                ("Marek Hastalığı", "Aşılama ve destekleyici bakım", 2800) } },
            { "İnek",   new() {
                ("Mastitis", "Antibiyotik ve meme pompası tedavisi", 6500),
                ("Şap Hastalığı", "Antiseptik yara bakımı ve aşı", 8900),
                ("Brucellosis", "Uzun süreli antibiyotik tedavisi", 7200) } },
            { "Keçi",   new() {
                ("Brucellosis", "Antibiyotik kombinasyon tedavisi", 5200),
                ("Akciğer İltihabı", "Antibiyotik ve solunum desteği", 4100),
                ("Enterotoksemi", "Antitoksin ve sıvı tedavisi", 4800) } },
            { "Yılan",  new() {
                ("Ağız Çürüklüğü", "Antibiyotik ve ağız temizliği", 3800),
                ("Solunum Enfeksiyonu", "Nebülizasyon ve antibiyotik", 3200),
                ("Inclusion Body Disease", "Destekleyici bakım ve izolasyon", 5500) } },
            { "Maymun", new() {
                ("Herpes B", "Antiviral ilaç ve karantina", 12000),
                ("Tüberküloz", "Uzun süreli çoklu antibiyotik", 15000),
                ("Sarı Humma", "Destekleyici tedavi ve aşılama", 18000) } },
            { "Balık",  new() {
                ("Beyaz Nokta Hastalığı", "Tuz banyosu ve ilaçlı su tedavisi", 950),
                ("Fin Rot", "Antibakteriyel ilaç ve su değişimi", 750),
                ("Dropsy", "Tuz banyosu ve antibiyotik", 1200) } },
            { "Van Gölü Canavarı", new() {
                ("Gizemli Ateş", "Gizemli ilaç ve dua", 9999),
                ("Varoluş Krizi", "Felsefe seansı", 9999),
                ("Kimlik Bunalımı", "Ayna terapisi", 9999) } }
        };

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
            if (randevu.HayvanTuru != null && _hastaliklar.ContainsKey(randevu.HayvanTuru))
            {
                var liste = _hastaliklar[randevu.HayvanTuru];
                var rastgele = new Random();
                var secilen = liste[rastgele.Next(liste.Count)];
                randevu.Hastalik = secilen.Hastalik;
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