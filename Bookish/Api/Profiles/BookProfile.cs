using Api.Dto;
using Application.Books.Commands.CreateBook;
using Application.Books.Queries.GetBookById;
using Application.Users.Commands.AddBookToList;
using Application.Users.Queries;
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

            CreateMap<AddToBookListDto, AddBookToListCommand>()
                .ForMember(p => p.UserId, opt => opt.MapFrom(s => s.UserId))
                .ForMember(p => p.BookId, opt => opt.MapFrom(s => s.BookId))
                .ForMember(p => p.FromListType, opt => opt.MapFrom(s => s.FromListType))
                .ForMember(p => p.ToListType, opt => opt.MapFrom(s => s.ToListType))
                .ReverseMap();

            CreateMap<ListTypeDto, BListType>()
                .ForMember(p => p.BookListType, opt => opt.MapFrom(s => s.ListType))
                .ReverseMap();
        }
    }
}
