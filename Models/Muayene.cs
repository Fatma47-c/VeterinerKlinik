namespace VeterinerKlinik.Models
{
    public class Muayene
    {
        public int Id { get; set; }
        public DateTime Tarih { get; set; }
        public string? Teshis { get; set; }
        public string? Tedavi { get; set; }
        public decimal Ucret { get; set; }
        public string? HayvanAdi { get; set; }
        public string? MusteriAdi { get; set; }
        public int VeterinerId { get; set; }
        public Veteriner? Veteriner { get; set; }
    }
}