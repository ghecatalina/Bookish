using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reviews.Queries.GetAllReviews
{
    public class GetAllReviewsQueryHandler : IRequestHandler<GetAllReviewsQuery, IEnumerable<Review>>
    {
        private readonly IReviewRepository _repository;
        public GetAllReviewsQueryHandler(IReviewRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Review>> Handle(GetAllReviewsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllReviews();
        }
    }
}
