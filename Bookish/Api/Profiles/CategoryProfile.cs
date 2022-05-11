using Api.Dto;
using Application.Categories.Commands.AddCategory;
using AutoMapper;
using Domain.Entities;

namespace Api.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryPutPostDto, AddCategoryCommand>()
                .ForMember(p => p.CategoryName, opt => opt.MapFrom(s => s.CategoryName))
                .ReverseMap();

            CreateMap<CategoryGetDto, Category>()
                .ForMember(p => p.CategoryName, opt => opt.MapFrom(s => s.CategoryName))
                .ForMember(p => p.Books, opt => opt.MapFrom(s => s.Books))
                .ReverseMap();
        }
    }
}
