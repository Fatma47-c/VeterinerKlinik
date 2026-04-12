namespace VeterinerKlinik.Models
{
    public abstract class Hayvan
    {
        public int Id { get; set; }
        public string Ad { get; set; } = null!;
        public int Yas { get; set; }
        public string Kategori { get; set; } = null!;
        public string Tur { get; set; } = null!;
        public string? Cins { get; set; }
        public string MusteriAdi { get; set; } = null!;

        public abstract string BakimBilgisi();
    }
}