namespace VeterinerKlinik.Models
{
    public abstract class Hayvan
    {
        public int Id { get; set; }
        public string Isim { get; set; } = null!;

        public int MusteriId { get; set; }
        public Musteri Musteri { get; set; } = null!;

        public abstract string SesCikar();
    }
}
