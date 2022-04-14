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
                .ForMember(p => p.UserName, opt => opt.MapFrom(s => s.RegularUserName))
                .ReverseMap();

            CreateMap<UserRegisterDto, RegularUser>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email))
                .ReverseMap();
        }
    }
}
