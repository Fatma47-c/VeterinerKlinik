namespace VeterinerKlinik.Models
{
    public class Veteriner
    {
        public int Id { get; set; }
        public string Ad { get; set; } = null!;
        public string Soyad { get; set; } = null!;
        public string UzmanlikAlani { get; set; } = null!;

        public List<Randevu> Randevular { get; set; } = new();
    }
}