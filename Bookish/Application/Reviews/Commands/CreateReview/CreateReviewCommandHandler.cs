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
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;
        public CreateReviewCommandHandler(IReviewRepository repository, IUserRepository userRepository, IBookRepository bookRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }
        public async Task<Review> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.UserId);
            var book = await _bookRepository.GetById(request.BookId);
            var review = new Review { BookId = request.BookId, Book = book, UserId = request.UserId, User = user, Rating = request.Rating, ReviewDescription = request.ReviewDescription };
            await _repository.Add(review);
            return review;
        }
    }
}
