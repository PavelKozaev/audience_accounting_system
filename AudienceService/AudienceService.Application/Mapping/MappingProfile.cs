using AudienceService.Application.Contracts;
using AudienceService.Domain;
using AutoMapper;

namespace AudienceService.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Audience,AudienceDto>().ReverseMap();
            CreateMap<Audience, AudienceCreateDto>().ReverseMap();
            CreateMap<Audience, AudienceUpdateDto>().ReverseMap();

            CreateMap<Building, BuildingDto>().ReverseMap();            
        }
    }
}
