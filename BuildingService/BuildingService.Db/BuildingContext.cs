using BuildingService.Domain;
using Microsoft.EntityFrameworkCore;

namespace BuildingService.Db
{
    public class BuildingContext : DbContext
    {
        public BuildingContext(DbContextOptions<BuildingContext> options) : base(options)
        {     
            Database.Migrate();
        }

        public DbSet<Building> Buildings { get; set; }
    }
}
