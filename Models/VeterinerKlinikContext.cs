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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hayvan>()
                .HasDiscriminator<string>("HayvanTipi")
                .HasValue<EvcilHayvan>("Evcil")
                .HasValue<CiftlikHayvani>("Çiftlik")
                .HasValue<EgzotikHayvan>("Egzotik");
        }
    }
}