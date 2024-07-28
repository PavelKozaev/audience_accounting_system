using AudienceService.Domain;

namespace AudienceService.Repository
{
    public interface IAudienceRepository
    {
        Task<List<Audience>> GetAudiencesAsync();
        Task<Audience> GetAudienceByIdAsync(int id);
        Task AddAudienceAsync(Audience audience);
        Task UpdateAudienceAsync(Audience audience);
        Task DeleteAudienceAsync(Audience audience);
        Task<List<Audience>> GetAudiencesByBuildingIdAsync(int buildingId);        
    }
}
