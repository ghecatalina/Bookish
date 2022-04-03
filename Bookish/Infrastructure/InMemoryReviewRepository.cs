using Application;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class InMemoryReviewRepository : IReviewRepository
    {
        private List<Review> _reviews;
        public InMemoryReviewRepository()
        {
            _reviews = new List<Review>();
        }
        public void AddReview(Review review, RegularUser user, Book book)
        {
            if (user.Read.Books.Contains(book) == false)
                return;
            review.UserId = user.Id;
            review.User = user;
            review.BookId = book.Id;
            review.Book = book;
            _reviews.Add(review);
        }

        public Review CreateReview(string description, double rating, RegularUser user, Book book)
        {
            return new Review { ReviewDescription = description,Rating = rating, UserId = user.Id, BookId = book.Id, User = user, Book = book };
        }

        public IEnumerable<Review> GetReviews()
        {
            return _reviews;
        }

        public IEnumerable<Review> GetReviewsByBook(int bookId)
        {
            return _reviews.Where(review => review.BookId == bookId);
        }

        public IEnumerable<Review> GetReviewsByUser(int userId)
        {
            return _reviews.Where(review => review.UserId == userId);
        }
    }
}
