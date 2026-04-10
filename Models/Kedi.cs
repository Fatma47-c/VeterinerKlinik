using VeterinerKlinik.Models;

namespace VeterinerKlinik.Models
{
    public class Kedi : Hayvan
    {
        public string Irk { get; set; } = null!;

        public override string SesCikar()
        {
            return "Miyav";
        }
    }
}
