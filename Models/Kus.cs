namespace VeterinerKlinik.Models
{
    public class Kus : Hayvan
    {
        public bool KonusabiliyorMu { get; set; }

        public override string SesCikar()
        {
            return "Cik Cik";
        }
    }
}
