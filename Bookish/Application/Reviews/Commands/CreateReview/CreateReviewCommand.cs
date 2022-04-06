using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reviews.Commands.CreateReview
{
    public class CreateReviewCommand : IRequest<Review>
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public double Rating { get; set; }
        public string ReviewDescription { get; set; }
    }
}
