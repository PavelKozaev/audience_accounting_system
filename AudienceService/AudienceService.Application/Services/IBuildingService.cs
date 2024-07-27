using AudienceService.Application.Contracts;

namespace AudienceService.Application.Services
{
    public interface IBuildingService
    {
        Task<List<BuildingDto>> GetBuildingsAsync();
        Task<BuildingDto> GetBuildingByIdAsync(int id);
        Task<int> AddBuildingAsync(BuildingDto buildingDto);
        Task UpdateBuildingAsync(int id, BuildingDto buildingDto);
        Task DeleteBuildingAsync(int id);              
    }
}
