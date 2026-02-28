namespace VeterinerKlinik.Models
{
    public class Kopek : Hayvan
    {
        public string Cins { get; set; } = null!;

        public override string SesCikar()
        {
            return "Hav Hav";
        }
    }
}
