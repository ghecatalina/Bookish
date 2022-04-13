using Domain;
using System;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IReviewRepository : IRepository<Review>
    {
        Task<IEnumerable<Review>> GetReviewsByUser(int userId);
        Task<IEnumerable<Review>> GetReviewsByBook(int bookId);
        Task<Review> GetReviewsByUserAndBook(int userId, int bookId);
    }
}
