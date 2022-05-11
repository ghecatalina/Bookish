using Api.Dto;
using Application.Reviews.Commands.CreateReview;
using Application.Reviews.Commands.UpdateReview;
using Application.Reviews.Queries.GetNoOfReviews;
using AutoMapper;
using Domain;

namespace Api.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<ReviewPutPostDto, CreateReviewCommand>()
                .ForMember(p => p.UserId, opt => opt.MapFrom(s => s.UserId))
                .ForMember(p => p.BookId, opt => opt.MapFrom(s => s.BookId))
                .ForMember(p => p.Rating, opt => opt.MapFrom(s => s.Rating))
                .ForMember(p => p.ReviewDescription, opt => opt.MapFrom(s => s.ReviewDescription))
                .ReverseMap();

            CreateMap<ReviewGetDto, Review>()
                .ForMember(p => p.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(p => p.UserId, opt => opt.MapFrom(s => s.UserId))
                .ForMember(p => p.Rating, opt => opt.MapFrom(s => s.Rating))
                .ForPath(p => p.User.ProfilePicture, opt => opt.MapFrom(s => s.Photo))
                .ForMember(p => p.ReviewDescription, opt => opt.MapFrom(s => s.ReviewDescription))
                .ForPath(p => p.User.Name, opt => opt.MapFrom(s => s.Username))
                .ReverseMap();

            CreateMap<RatingGroupDto, RatingGroup>()
                .ForMember(p => p.Rating, opt => opt.MapFrom(s => s.Rating))
                .ForMember(p => p.RatingNo, opt => opt.MapFrom(s => s.NoRating))
                .ReverseMap();

            CreateMap<ReviewPutPostDto, UpdateReviewCommand>()
                .ForMember(p => p.UserId, opt => opt.MapFrom(s => s.UserId))
                .ForMember(p => p.BookId, opt => opt.MapFrom(s => s.BookId))
                .ForMember(p => p.Rating, opt => opt.MapFrom(s => s.Rating))
                .ForMember(p => p.ReviewDescription, opt => opt.MapFrom(s => s.ReviewDescription))
                .ReverseMap();
        }
    }
}
