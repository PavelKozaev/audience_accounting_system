using AudienceService.Application.Contracts;

namespace AudienceService.Application.Services
{
    public interface IAudienceService
    {
        Task<List<AudienceDto>> GetAudiencesAsync();
        Task<AudienceDto> GetAudienceByIdAsync(int id);
        Task<int> AddAudienceAsync(AudienceCreateDto audienceCreateDto);
        Task UpdateAudienceAsync(int id, AudienceUpdateDto audienceUpdateDto);
        Task DeleteAudienceAsync(int id);
        Task<List<AudienceDto>> GetAudiencesByBuildingIdAsync(int buildingId);
    }
}
