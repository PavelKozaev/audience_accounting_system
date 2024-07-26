using AutoMapper;
using BuildingService.Api.Models;
using BuildingService.Domain;

namespace BuildingService.Api.Mapping
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
