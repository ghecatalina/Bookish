using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(AppDbContext context) : base(context)
        {
        }
        private AppDbContext appDbContext
        {
            get { return _context as AppDbContext; }
        }

        public async Task<IEnumerable<Review>> GetReviewsByBook(int bookId)
        {
            return await appDbContext.Reviews.Where(review => review.BookId == bookId).ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetReviewsByUser(int userId)
        {
            return await appDbContext.Reviews.Where(review => review.UserId == userId).ToListAsync();
        }

        public async Task<Review> GetReviewsByUserAndBook(int userId, int bookId)
        {
            return await appDbContext.Reviews.Where(review => review.UserId == userId && review.BookId == bookId).SingleOrDefaultAsync();
        }
    }
}
