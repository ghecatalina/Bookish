using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reviews.Commands.CreateReview
{
    internal class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, Review>
    {
        private readonly IReviewRepository _repository;
        public CreateReviewCommandHandler(IReviewRepository repository)
        {
            _repository = repository;
        }
        public Task<Review> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = new Review { BookId = request.BookId, UserId = request.UserId, Rating = request.Rating, ReviewDescription = request.ReviewDescription };
            _repository.Add(review);
            return Task.FromResult(review);
        }
    }
}
