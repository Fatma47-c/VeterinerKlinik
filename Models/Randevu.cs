namespace VeterinerKlinik.Models
{
    public class Randevu
    {
        public int Id { get; set; }
        public DateTime Tarih { get; set; }
        public string? MusteriAdi { get; set; }
        public string? Telefon { get; set; }
        public string? HayvanTuru { get; set; } 
        public string? HayvanCinsi { get; set; }
        public string? Hastalik { get; set; }
        public string? Tedavi { get; set; }
        public decimal? Ucret { get; set; }
        public string? Aciklama { get; set; }

        public int VeterinerId { get; set; }
        public Veteriner? Veteriner { get; set; }
    }
}