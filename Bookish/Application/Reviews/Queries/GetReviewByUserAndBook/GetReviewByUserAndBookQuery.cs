using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reviews.Queries.GetReviewByUserAndBook
{
    public class GetReviewByUserAndBookQuery : IRequest<Review>
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
    }
}
