using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reviews.Queries.GetRating
{
    public class GetRatingQuery : IRequest<RatingDto>
    {
        public int BookId { get; set; }
    }
}
