using AutoMapper;
using BuildingService.Application.Contracts;
using BuildingService.Domain;
using BuildingService.Integrations;
using BuildingService.Repository;
using Common.Messages;

namespace BuildingService.Application.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository _repository;
        private readonly IMapper _mapper;
        private readonly IMessageSender _messageSender;        

        public BuildingService(IBuildingRepository repository, IMapper mapper, IMessageSender messageSender)
        {
            _repository = repository;
            _mapper = mapper;
            _messageSender = messageSender;
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

            var message = new BuildingEventMessage
            {
                Id = building.Id,
                Name = building.Name,
                Address = building.Address,
                Floors = building.Floors,
                EventType = "Created"
            };
            await _messageSender.SendMessageAsync(message);

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

            var message = new BuildingEventMessage
            {
                Id = building.Id,
                Name = building.Name,
                Address = building.Address,
                Floors = building.Floors,
                EventType = "Updated"
            };
            await _messageSender.SendMessageAsync(message);
        }

        public async Task DeleteBuildingAsync(int id)
        {
            var building = await _repository.GetBuildingByIdAsync(id);
            if (building == null || building.IsDeleted)
            {
                throw new KeyNotFoundException("Building not found");
            }
            await _repository.DeleteBuildingAsync(building);

            var message = new BuildingEventMessage
            {
                Id = building.Id,
                Name = building.Name,
                Address = building.Address,
                Floors = building.Floors,
                EventType = "Deleted"
            };
            await _messageSender.SendMessageAsync(message);
        }
    }
}
