namespace VeterinerKlinik.Models
{
    public abstract class Hayvan
    {
        public int Id { get; set; }
        public string Ad { get; set; } = null!;
        public int Yas { get; set; }

        public int MusteriId { get; set; }
        public Musteri Musteri { get; set; } = null!;

        public abstract string SesCikar();
    }
}
