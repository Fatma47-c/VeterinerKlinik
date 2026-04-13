using VeterinerKlinik.Models;

public class Musteri
{
    public int Id { get; set; }

    public string? Ad { get; set; }
    public string? Soyad { get; set; }
    public string? Telefon { get; set; }

    public List<Hayvan> Hayvanlar { get; set; } = new();
}
