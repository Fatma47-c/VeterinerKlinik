namespace VeterinerKlinik.Models
{
    public class DashboardViewModel
    {
       
        public int ToplamRandevuSayisi { get; set; }
        public int BugunkuRandevuSayisi { get; set; }
        public int ToplamVeterinerSayisi { get; set; }
        public int ToplamHayvanSayisi { get; set; }
        public int ToplamMusteriSayisi { get; set; }
        public int ToplamMuayeneSayisi { get; set; }
       
        public decimal ToplamGelir { get; set; }
        public decimal BugunkuGelir { get; set; }
        public decimal MuayeneToplamGelir { get; set; }
        
        public List<Randevu> BugunkuRandevular { get; set; } = new();
        public List<Randevu> SonRandevular { get; set; } = new();
        public List<Veteriner> Veterinerler { get; set; } = new();
        public List<Muayene> SonMuayeneler { get; set; } = new();
    }
}