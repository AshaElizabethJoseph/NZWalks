using AutoMapper;
using Microsoft.AspNetCore.Routing.Constraints;

namespace NZWalks.API.Models.Profiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<Models.Domain.Region, Models.DTO.Region>()  //Source , Destination
                .ReverseMap();
                //.ForMember(dest => dest.Id, options => options.MapFrom(src => src.regionId));
        }
    }
}
