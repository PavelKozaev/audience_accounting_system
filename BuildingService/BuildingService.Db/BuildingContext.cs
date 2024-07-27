using BuildingService.Domain;
using Microsoft.EntityFrameworkCore;

namespace BuildingService.Db
{
    public class BuildingContext : DbContext
    {
        public DbSet<Building> Buildings { get; set; }

        public BuildingContext(DbContextOptions<BuildingContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);                        
            modelBuilder.Entity<Building>().HasQueryFilter(b => !b.IsDeleted);
        }
    }
}
