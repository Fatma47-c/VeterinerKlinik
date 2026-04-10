namespace VeterinerKlinik.Models
{
    public class Kopek : Hayvan
    {
        public string Irk { get; set; } = null!;
        public string Boyut { get; set; } = null!;

        public override string SesCikar()
        {
            return "Hav Hav";
        }
    }
}
