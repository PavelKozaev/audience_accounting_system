using AutoMapper;
using BuildingService.Application.Contracts;
using BuildingService.Domain;
using BuildingService.Repository;

namespace BuildingService.Application.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository _repository;
        private readonly IMapper _mapper;

        public BuildingService(IBuildingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<BuildingDto>> GetBuildingsAsync()
        {
            var buildings = await _repository.GetBuildingsAsync();
            return _mapper.Map<List<BuildingDto>>(buildings);
        }

        public async Task<BuildingDto> GetBuildingByIdAsync(int id)
        {
            var building = await _repository.GetBuildingByIdAsync(id);
            if (building == null || building.IsDeleted)
            {
                throw new KeyNotFoundException("Building not found");
            }
            return _mapper.Map<BuildingDto>(building);
        }

        public async Task<int> AddBuildingAsync(BuildingCreateDto buildingCreateDto)
        {
            var building = _mapper.Map<Building>(buildingCreateDto);
            await _repository.AddBuildingAsync(building);
            return building.Id; 
        }

        public async Task UpdateBuildingAsync(int id, BuildingUpdateDto buildingUpdateDto)
        {
            var building = await _repository.GetBuildingByIdAsync(id);
            if (building == null || building.IsDeleted)
            {
                throw new KeyNotFoundException("Building not found");
            }
            _mapper.Map(buildingUpdateDto, building);
            await _repository.UpdateBuildingAsync(building);
        }

        public async Task DeleteBuildingAsync(int id)
        {
            var building = await _repository.GetBuildingByIdAsync(id);
            if (building == null || building.IsDeleted)
            {
                throw new KeyNotFoundException("Building not found");
            }
            await _repository.DeleteBuildingAsync(building);
        }
    }
}
