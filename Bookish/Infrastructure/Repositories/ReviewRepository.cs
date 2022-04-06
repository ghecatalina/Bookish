using Application;
using Application.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Review> GetReviewsByBook(int bookId)
        {
            return GetAll().Where(r => r.BookId == bookId);
        }

        public IEnumerable<Review> GetReviewsByUser(int userId)
        {
            return GetAll().Where(r => r.UserId == userId);
        }

        public Review GetReviewsByUserAndBook(int userId, int bookId)
        {
            return GetAll().Where(r => r.UserId == userId && r.BookId == bookId).FirstOrDefault();
        }
    }
}
