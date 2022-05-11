using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reviews.Queries.GetReviewsByBook
{
    public class GetReviewsByBookQuery : IRequest<IEnumerable<Review>>
    {
        public int BookId { get; set; }
        public Guid UserId { get; set; }
    }
}
