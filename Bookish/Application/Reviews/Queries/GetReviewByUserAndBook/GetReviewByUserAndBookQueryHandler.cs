using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reviews.Queries.GetReviewByUserAndBook
{
    internal class GetReviewByUserAndBookQueryHandler : IRequestHandler<GetReviewByUserAndBookQuery, Review>
    {
        private readonly IReviewRepository _repository;
        public GetReviewByUserAndBookQueryHandler(IReviewRepository repository)
        {
            _repository = repository;
        }
        public Task<Review> Handle(GetReviewByUserAndBookQuery request, CancellationToken cancellationToken)
        {
            var review = _repository.GetReviewsByUserAndBook(request.UserId, request.BookId);
            return review;
            
        }
    }
}
