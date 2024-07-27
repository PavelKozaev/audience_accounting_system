using AudienceService.Application.Contracts;
using AudienceService.Domain;
using AudienceService.Repository;
using AutoMapper;


namespace AudienceService.Application.Services
{
    public class AudienceService : IAudienceService
    {
        private readonly IAudienceRepository _audienceRepository;
        private readonly IBuildingRepository _buildingRepository;
        private readonly IMapper _mapper;

        public AudienceService(IAudienceRepository audienceRepository, IMapper mapper, IBuildingRepository buildingRepository)
        {
            _audienceRepository = audienceRepository;
            _buildingRepository = buildingRepository;
            _mapper = mapper;
        }

        public async Task<List<AudienceDto>> GetAudiencesAsync()
        {
            var audiences = await _audienceRepository.GetAudiencesAsync();
            return _mapper.Map<List<AudienceDto>>(audiences);
        }

        public async Task<AudienceDto> GetAudienceByIdAsync(int id)
        {
            var audience = await _audienceRepository.GetAudienceByIdAsync(id);
            if (audience == null || audience.IsDeleted)
            {
                throw new KeyNotFoundException("Audience not found");
            }
            return _mapper.Map<AudienceDto>(audience);
        }

        public async Task<int> AddAudienceAsync(AudienceCreateDto audienceCreateDto)
        {
            var building = await _buildingRepository.GetBuildingByIdAsync(audienceCreateDto.BuildingId);
            if (building == null)
            {
                throw new KeyNotFoundException("Building not found");
            }

            var audience = _mapper.Map<Audience>(audienceCreateDto);
            await _audienceRepository.AddAudienceAsync(audience);
            return audience.Id;
        }

        public async Task UpdateAudienceAsync(int id, AudienceUpdateDto audienceUpdateDto)
        {
            var building = await _buildingRepository.GetBuildingByIdAsync(audienceUpdateDto.BuildingId);
            if (building == null)
            {
                throw new KeyNotFoundException("Building not found");
            }

            var audience = await _audienceRepository.GetAudienceByIdAsync(id);
            if (audience == null || audience.IsDeleted)
            {
                throw new KeyNotFoundException("Audience not found");
            }
            _mapper.Map(audienceUpdateDto, audience);
            await _audienceRepository.UpdateAudienceAsync(audience);
        }

        public async Task DeleteAudienceAsync(int id)
        {
            var audience = await _audienceRepository.GetAudienceByIdAsync(id);
            if (audience == null || audience.IsDeleted)
            {
                throw new KeyNotFoundException("Audience not found");
            }
            await _audienceRepository.DeleteAudienceAsync(audience);
        }
    }
}
