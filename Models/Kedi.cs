using VeterinerKlinik.Models;

namespace VeterinerKlinik.Models
{
    public class Kedi : Hayvan
    {
        public string IrkTipi { get; set; } = null!;

        public override string SesCikar()
        {
            return "Miyav";
        }
    }
}
