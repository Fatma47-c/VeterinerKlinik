namespace VeterinerKlinik.Models
{
    public class Hastalik
    {
        public int Id { get; set; }
        public string Ad { get; set; } = string.Empty;
        public string Tedavi { get; set; } = string.Empty;
        public decimal Ucret { get; set; }
    }
}