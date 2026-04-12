namespace VeterinerKlinik.Models
{
    public class EvcilHayvan : Hayvan
    {
        public override string BakimBilgisi()
        {
            return "Düzenli aşı, günlük mama ve veteriner kontrolü gerektirir.";
        }
    }
}