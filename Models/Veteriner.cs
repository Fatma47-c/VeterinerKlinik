namespace VeterinerKlinik.Models
{
    public class Veteriner
    {
        public int Id { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public string? UzmanlikAlani { get; set; }

        public List<Randevu> Randevular { get; set; } = new();
    }
}