using Api.Dto;
using AutoMapper;
using Domain;

namespace Api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserAuthDto, User>()
                .ForMember(p => p.Email, opt => opt.MapFrom(s => s.RegularUserEmail))
                .ReverseMap();

            CreateMap<UserWithBookListsDto, User>()
                .ForMember(p => p.Id, opt => opt.MapFrom(s => s.Id))
                .ForPath(p => p.Read.Books, opt => opt.MapFrom(s => s.Read))
                .ForPath(p => p.CurrentlyReading.Books, opt => opt.MapFrom(s => s.CurrentlyReading))
                .ForPath(p => p.WantToRead.Books, opt => opt.MapFrom(s => s.WantToRead))
                .ForMember(p => p.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(p => p.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(p => p.ProfilePicture, opt => opt.MapFrom(s => s.ProfilePicture))
                .ReverseMap();

            CreateMap<ProfilePictureDto, User>()
                .ForMember(p => p.ProfilePicture, opt => opt.MapFrom(s => s.ProfilePicture))
                .ReverseMap();
            
            CreateMap<UserInfoDto, User>()
                .ForMember(p => p.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(p => p.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(p => p.ProfilePicture, opt => opt.MapFrom(s => s.ProfilePicture))
                .ReverseMap();

        }
    }
}
