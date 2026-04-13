using System;

namespace VeterinerKlinik.Models
{
    public class Muayene
    {
        public int Id { get; set; }
        public DateTime Tarih { get; set; }
        public string? Teshis { get; set; }
        public decimal Ucret { get; set; }

        public int HayvanId { get; set; }
        public Hayvan? Hayvan { get; set; }
    }
}
