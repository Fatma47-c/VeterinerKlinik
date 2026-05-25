using Microsoft.EntityFrameworkCore;

namespace VeterinerKlinik.Models
{
    public class VeterinerKlinikContext : DbContext
    {
        public VeterinerKlinikContext(DbContextOptions<VeterinerKlinikContext> options)
            : base(options)
        {
        }

        public DbSet<Randevu> Randevular => Set<Randevu>();
        public DbSet<Veteriner> Veterinerler => Set<Veteriner>();
        public DbSet<Hastalik> Hastaliklar => Set<Hastalik>();
        public DbSet<Muayene> Muayeneler => Set<Muayene>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hastalik>()
                .Property(h => h.Ucret)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Randevu>()
                .Property(r => r.Ucret)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Muayene>()
                .Property(m => m.Ucret)
                .HasPrecision(18, 2);
        }
    }
}