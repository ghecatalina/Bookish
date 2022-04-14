using Api.Dto;
using AutoMapper;
using Domain;

namespace Api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserAuthDto, RegularUser>()
                .ForMember(p => p.Email, opt => opt.MapFrom(s => s.RegularUserEmail))
                .ReverseMap();

        }
    }
}
