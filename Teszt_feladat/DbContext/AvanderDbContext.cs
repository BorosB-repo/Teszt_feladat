
using Microsoft.EntityFrameworkCore;
using Teszt_feladat.Entities;

namespace Teszt_feladat
{
    public class AvanderDbContext : DbContext
    {
        public AvanderDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Vechicle> Vechicles { get; set; }

        public DbSet<Shop> Shops { get; set; }

        public DbSet<MeasurementPoint> MeasurementPoints { get; set; }

        public DbSet<Measurement> Measurements { get; set; }
    }
}
