using Domain;
using System;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IReviewRepository : IRepository<Review>
    {
        Task<IEnumerable<Review>> GetAllReviews();
        Task<IEnumerable<Review>> GetReviewsByUser(Guid userId);
        Task<IEnumerable<Review>> GetReviewsByBook(int bookId);
        Task<Review> GetReviewsByUserAndBook(Guid userId, int bookId);
        Task<Review> GetReviewById(int id);
        Task UpdateReview(Review review);
    }
}
