using AudienceService.Domain;
using Microsoft.EntityFrameworkCore;

namespace AudienceService.Db
{
    public class AudienceContext : DbContext
    {
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Audience> Audiences { get; set; }

        public AudienceContext(DbContextOptions<AudienceContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Building>().HasQueryFilter(b => !b.IsDeleted);
            modelBuilder.Entity<Audience>().HasQueryFilter(r => !r.IsDeleted);

            modelBuilder.Entity<Audience>()
                .HasOne(r => r.Building)
                .WithMany(b => b.Audiences)
                .HasForeignKey(r => r.BuildingId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
