using AutoMapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region,RegionDTO>().ReverseMap();
            CreateMap<Region, AddNewRegionDTO>().ReverseMap();
            CreateMap<Region, UpdateDTO>().ReverseMap();
            CreateMap<Walk, AddNewWalkDTO>().ReverseMap();
            CreateMap<Walk, WalkDTO>().ReverseMap();
            CreateMap<DifficultyDTO, Difficulty>().ReverseMap();
            CreateMap<UpdateWalkDTO, Walk>().ReverseMap();
        }
    }
}
