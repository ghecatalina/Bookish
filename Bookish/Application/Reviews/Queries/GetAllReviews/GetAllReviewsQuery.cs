using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reviews.Queries.GetAllReviews
{
    public class GetAllReviewsQuery : IRequest<IEnumerable<Review>>
    {
    }
}
