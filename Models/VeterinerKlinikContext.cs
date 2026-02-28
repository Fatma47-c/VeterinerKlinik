using Microsoft.EntityFrameworkCore;
using VeterinerKlinik.Models;

namespace VeterinerKlinik.Data
{
    public class VeterinerKlinikContext : DbContext
    {
        public VeterinerKlinikContext(DbContextOptions<VeterinerKlinikContext> options)
            : base(options) { }

        public DbSet<Musteri> Musteriler => Set<Musteri>();
        public DbSet<Hayvan> Hayvanlar => Set<Hayvan>();

        public DbSet<Randevu> Randevular => Set<Randevu>();
        public DbSet<Veteriner> Veterinerler => Set<Veteriner>();
        public DbSet<Muayene> Muayeneler => Set<Muayene>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hayvan>()
                .HasDiscriminator<string>("HayvanTipi")
                .HasValue<Kedi>("Kedi")
                .HasValue<Kopek>("Kopek")
                .HasValue<Kus>("Kus");

            modelBuilder.Entity<Muayene>()
                .Property(m => m.Ucret)
                .HasPrecision(10, 2);

            base.OnModelCreating(modelBuilder);
        }

    }
}
