namespace VeterinerKlinik.Models
{
    public class CiftlikHayvani : Hayvan
    {
        public override string BakimBilgisi()
        {
            return "Mevsimlik aşı, özel barınak ve beslenme programı gerektirir.";
        }
    }
}