using BuildingService.Db;
using BuildingService.Domain;
using Microsoft.EntityFrameworkCore;

namespace BuildingService.Repository
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly BuildingContext _context;

        public BuildingRepository(BuildingContext context)
        {
            _context = context;
        }

        public async Task<List<Building>> GetBuildingsAsync()
        {
            return await _context.Buildings.ToListAsync();
        }

        public async Task<Building> GetBuildingByIdAsync(int id)
        {
            return await _context.Buildings.FindAsync(id);
        }

        public async Task AddBuildingAsync(Building building)
        {
            _context.Buildings.Add(building);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBuildingAsync(Building building)
        {
            _context.Buildings.Update(building);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBuildingAsync(Building building)
        {
            _context.Buildings.Remove(building);
            await _context.SaveChangesAsync();
        }
    }
}
