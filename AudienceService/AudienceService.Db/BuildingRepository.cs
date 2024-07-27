using AudienceService.Domain;
using AudienceService.Repository;
using Microsoft.EntityFrameworkCore;

namespace AudienceService.Db
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly AudienceContext _db;

        public BuildingRepository(AudienceContext db)
        {
            _db = db;            
        }

        public async Task<List<Building>> GetBuildingsAsync()
        {
            return await _db.Buildings
                .Where(a => !a.IsDeleted)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Building> GetBuildingByIdAsync(int id)
        {
            return await _db.Buildings.FirstOrDefaultAsync(b => b.Id == id && !b.IsDeleted);
        }
        public async Task AddBuildingAsync(Building building)
        {
            _db.Buildings.Add(building);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateBuildingAsync(Building building)
        {
            _db.Buildings.Update(building);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteBuildingAsync(Building building)
        {
            building.IsDeleted = true;
            _db.Buildings.Update(building);
            await _db.SaveChangesAsync();
        }
    }
}
