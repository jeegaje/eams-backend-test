using Microsoft.EntityFrameworkCore;
using EAMS.Domain.Entities;

namespace EAMS.Infrastructure.Data
{
    public class EamsDbContext : DbContext
    {
        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<AmenityOptions> AmenityOptions { get; set; }

        public EamsDbContext(DbContextOptions<EamsDbContext> options) : base(options) {}
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EamsDbContext).Assembly);
        }
    }
}