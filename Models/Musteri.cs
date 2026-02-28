using VeterinerKlinik.Models;

public class Musteri
{
    public int Id { get; set; }

    public string Ad { get; set; } = null!;
    public string Soyad { get; set; } = null!;
    public string Telefon { get; set; } = null!;

    public List<Hayvan> Hayvanlar { get; set; } = new();
}
