using Domain;
using System;
using System.Collections.Generic;

namespace Application
{
    public interface IReviewRepository
    {
        IEnumerable<Review> GetReviews();
        IEnumerable<Review> GetReviewsByUser(int userId);
        IEnumerable<Review> GetReviewsByBook(int bookId);
        void AddReview(Review review, RegularUser user, Book book);

        Review CreateReview(string description, double rating, RegularUser user, Book book);
    }
}
