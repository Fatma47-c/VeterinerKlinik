namespace VeterinerKlinik.Models
{
    public class Kus : Hayvan
    {
        public string TurAdi { get; set; } = null!;

        public override string SesCikar()
        {
            return "Cik Cik";
        }
    }
}
