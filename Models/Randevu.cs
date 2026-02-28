using System;

namespace VeterinerKlinik.Models
{
    public class Randevu
    {
        public int Id { get; set; }
        public DateTime Tarih { get; set; }
        public string Aciklama { get; set; } = null!;

        public int HayvanId { get; set; }
        public Hayvan Hayvan { get; set; } = null!;
    }
}
