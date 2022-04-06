using Domain;
using System;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IReviewRepository : IRepository<Review>
    {
        IEnumerable<Review> GetReviewsByUser(int userId);
        IEnumerable<Review> GetReviewsByBook(int bookId);
    }
}
