using Api.Dto;
using Application.Books.Commands.CreateBook;
using Application.Books.Queries.GetBookById;
using AutoMapper;
using Domain;

namespace Api.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookDto, Book>()
                .ForMember(p => p.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(p => p.Title, opt => opt.MapFrom(s =>s.Title))
                .ForMember(p => p.Author, opt => opt.MapFrom(s => s.Author))
                .ReverseMap();

            CreateMap<BookPutPostDto, CreateBookCommand>()
                .ForMember(p => p.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(p => p.Author, opt => opt.MapFrom(s => s.Author))
                .ForMember(p => p.BookCoverImage, opt => opt.MapFrom(s => s.CoverImage))
                .ForMember(p => p.Description, opt => opt.MapFrom(s => s.Description))
                .ForPath(p => p.CategoryName, opt => opt.MapFrom(s => s.Genre))
                .ReverseMap();

            CreateMap<BookGetDto, Book>()
                .ForMember(p => p.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(p => p.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(p => p.Author, opt => opt.MapFrom(s => s.Author))
                .ForMember(p => p.BookCoverImage, opt => opt.MapFrom(s => s.CoverImage))
                .ForMember(p => p.Description, opt => opt.MapFrom(s => s.Description))
                .ForPath(p => p.Category.CategoryName, opt => opt.MapFrom(s => s.Genre))
                .ReverseMap();
        }
    }
}
