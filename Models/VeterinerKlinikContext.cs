using Microsoft.EntityFrameworkCore;

namespace VeterinerKlinik.Models
{
    public class VeterinerKlinikContext : DbContext
    {
        public VeterinerKlinikContext(DbContextOptions<VeterinerKlinikContext> options)
            : base(options)
        {
        }

        public DbSet<Hayvan> Hayvanlar => Set<Hayvan>();
        public DbSet<Randevu> Randevular => Set<Randevu>();
        public DbSet<Veteriner> Veterinerler => Set<Veteriner>();
        public DbSet<Muayene> Muayeneler => Set<Muayene>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hayvan>()
                .HasDiscriminator<string>("HayvanTipi")
                .HasValue<EvcilHayvan>("Evcil")
                .HasValue<CiftlikHayvani>("Çiftlik")
                .HasValue<EgzotikHayvan>("Egzotik");

            modelBuilder.Entity<Veteriner>().HasData(
                new Veteriner { Id = 1, Ad = "Uzm. Vet. Hek. Selin", Soyad = "Yılmaz", UzmanlikAlani = "Evcil Hayvanlar" },
                new Veteriner { Id = 2, Ad = "Vet. Hek. Ahmet", Soyad = "Demir", UzmanlikAlani = "Çiftlik Hayvanları" },
                new Veteriner { Id = 3, Ad = "Dr. Med. Vet. Murat", Soyad = "Aydın", UzmanlikAlani = "Egzotik Hayvanlar" }
            );
        }
    }
}