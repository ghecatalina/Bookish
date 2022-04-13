using Api.Dto;
using AutoMapper;
using Domain;

namespace Api.Profiles
{
    public class RegularUserProfile : Profile
    {
        public RegularUserProfile()
        {
            CreateMap<RegularUserGetDto, RegularUser>()
                .ForMember(p => p.Id, opt => opt.MapFrom(s => s.RegularUserId))
                .ForMember(p => p.Name, opt => opt.MapFrom(s =>s.RegularUserName))
                .ReverseMap();
        }
    }
}
