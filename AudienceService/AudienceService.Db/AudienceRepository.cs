using AudienceService.Domain;
using AudienceService.Repository;
using Microsoft.EntityFrameworkCore;

namespace AudienceService.Db
{
    public class AudienceRepository : IAudienceRepository
    {
        private readonly AudienceContext _db;

        public AudienceRepository(AudienceContext db)
        {
            _db = db;
        }
                
        public async Task<List<Audience>> GetAudiencesAsync()
        {
            return await _db.Audiences
                .Where(a => !a.IsDeleted)
                .AsNoTracking()
                .ToListAsync();            
        }

        public async Task<Audience> GetAudienceByIdAsync(int id)
        {
            return await _db.Audiences.FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
        }

        public async Task AddAudienceAsync(Audience audience)
        {
            _db.Audiences.Add(audience);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAudienceAsync(Audience audience)
        {
            _db.Audiences.Update(audience);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAudienceAsync(Audience audience)
        {
            audience.IsDeleted = true;
            _db.Audiences.Update(audience);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Audience>> GetAudiencesByBuildingIdAsync(int buildingId)
        {
            return await _db.Audiences
                .Where(a => a.Building.Id == buildingId && !a.IsDeleted)
                .ToListAsync();
        }
    }
}
