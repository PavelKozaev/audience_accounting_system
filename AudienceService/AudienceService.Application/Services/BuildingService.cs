using AudienceService.Application.Contracts;
using AudienceService.Domain;
using AudienceService.Repository;
using AutoMapper;

namespace AudienceService.Application.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IAudienceRepository _audienceRepository;
        private readonly IBuildingRepository _buildingRepository;
        private readonly IMapper _mapper;

        public BuildingService(IAudienceRepository audienceRepository, IMapper mapper, IBuildingRepository buildingRepository)
        {
            _audienceRepository = audienceRepository;
            _buildingRepository = buildingRepository;
            _mapper = mapper;
        }

        public async Task<List<BuildingDto>> GetBuildingsAsync()
        {
            var buildings = await _buildingRepository.GetBuildingsAsync();
            return _mapper.Map<List<BuildingDto>>(buildings);
        }

        public async Task<BuildingDto> GetBuildingByIdAsync(int id)
        {
            var building = await _buildingRepository.GetBuildingByIdAsync(id);
            if (building == null || building.IsDeleted)
            {
                throw new KeyNotFoundException("Building not found");
            }
            return _mapper.Map<BuildingDto>(building);
        }

        public async Task<int> AddBuildingAsync(BuildingCreateDto buildingCreateDto)
        {
            var building = _mapper.Map<Building>(buildingCreateDto);
            await _buildingRepository.AddBuildingAsync(building);
            return building.Id;
        }

        public async Task UpdateBuildingAsync(int id, BuildingUpdateDto buildingUpdateDto)
        {
            var building = await _buildingRepository.GetBuildingByIdAsync(id);
            if (building == null || building.IsDeleted)
            {
                throw new KeyNotFoundException("Building not found");
            }
            _mapper.Map(buildingUpdateDto, building);
            await _buildingRepository.UpdateBuildingAsync(building);
        }

        public async Task DeleteBuildingAsync(int id)
        {
            var building = await _buildingRepository.GetBuildingByIdAsync(id);
            if (building == null || building.IsDeleted)
            {
                throw new KeyNotFoundException("Building not found");
            }

            var audiences = await _audienceRepository.GetAudiencesByBuildingIdAsync(id);
            foreach (var audience in audiences)
            {
                await _audienceRepository.DeleteAudienceAsync(audience);
            }

            await _buildingRepository.DeleteBuildingAsync(building);
        }
    }
}
