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

        
    }
}