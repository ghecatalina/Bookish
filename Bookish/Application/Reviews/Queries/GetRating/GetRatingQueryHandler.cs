using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reviews.Queries.GetRating
{
    public class GetRatingQueryHandler : IRequestHandler<GetRatingQuery, RatingDto>
    {
        private readonly IBookRepository _repository;
        public GetRatingQueryHandler(IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task<RatingDto> Handle(GetRatingQuery request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetBookById(request.BookId);
            var ratingValue = 0.0;
            if (book.Reviews.Count == 0)
            {
                return new RatingDto() { Rating = ratingValue };
            }
            foreach (var review in book.Reviews)
            {
                ratingValue += review.Rating;
            }
            ratingValue /= book.Reviews.Count; 
            //var ratingValue = book.Reviews.Average(x => x.Rating);
            var rating = new RatingDto() { Rating = ratingValue };
            return rating;
        }
    }
}
