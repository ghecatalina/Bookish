﻿using Application.Interfaces;
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
        public Task<IEnumerable<Review>> Handle(GetReviewsByBookQuery request, CancellationToken cancellationToken)
        {

            var reviews = _repository.GetReviewsByBook(request.BookId);
            return Task.FromResult(reviews);
        }
    }
}
