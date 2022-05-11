using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reviews.Queries.GetReviewsByBook
{
    public class GetReviewByBookQueryHandler : IRequestHandler<GetReviewsByBookQuery, IEnumerable<Review>>
    {
        private readonly IReviewRepository _repository;
        public GetReviewByBookQueryHandler(IReviewRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Review>> Handle(GetReviewsByBookQuery request, CancellationToken cancellationToken)
        {

            var reviews = await _repository.GetReviewsByBook(request.BookId);
            reviews = reviews.Where(r => r.UserId != request.UserId);
            return reviews;
        }
    }
}
