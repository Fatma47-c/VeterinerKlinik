namespace VeterinerKlinik.Models
{
    public abstract class Hayvan
    {
        public int? Id { get; set; }
        public string? Ad { get; set; }
        public int? Yas { get; set; }
        public string? Kategori { get; set; }
        public string? Tur { get; set; }
        public string? Cins { get; set; }
        public string? MusteriAdi { get; set; }

        public abstract string BakimBilgisi();
    }
}