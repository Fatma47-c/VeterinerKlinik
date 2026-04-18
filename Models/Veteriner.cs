namespace VeterinerKlinik.Models
{
    public class Veteriner
    {
        public int Id { get; set; }
        public string Ad { get; set; } = string.Empty;
        public string Soyad { get; set; } = string.Empty;
        public string UzmanlikAlani { get; set; } = string.Empty;
        public string Universite { get; set; } = string.Empty;
        public int DeneyimYili { get; set; }
        public string Unvan { get; set; } = string.Empty;
        public string Cinsiyet { get; set; } = string.Empty;
        public List<Randevu> Randevular { get; set; } = new();
    }
}