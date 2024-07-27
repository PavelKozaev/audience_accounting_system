using AutoMapper;
using BuildingService.Application.Contracts;
using BuildingService.Domain;

namespace BuildingService.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Building, BuildingDto>().ReverseMap();
            CreateMap<Building, BuildingCreateDto>().ReverseMap();
            CreateMap<Building, BuildingUpdateDto>().ReverseMap();
        }
    }
}
