﻿using BuildingService.Db;
using BuildingService.Domain;
using Microsoft.EntityFrameworkCore;

namespace BuildingService.Repository
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly BuildingContext _db;

        public BuildingRepository(BuildingContext db)
        {
            _db = db;
        }

        public async Task<List<Building>> GetBuildingsAsync()
        {
            return await _db.Buildings
                .Where(b => !b.IsDeleted)
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
