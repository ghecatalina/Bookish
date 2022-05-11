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
            return await appDbContext.Reviews
                .Include(r => r.User)
                .Where(review => review.BookId == bookId).ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetReviewsByUser(Guid userId)
        {
            return await appDbContext.Reviews.Where(review => review.UserId == userId).ToListAsync();
        }

        public async Task<Review> GetReviewsByUserAndBook(Guid userId, int bookId)
        {
            return await appDbContext.Reviews.Where(review => review.UserId == userId && review.BookId == bookId).SingleOrDefaultAsync();
        }

        public async Task<Review> GetReviewById(int id)
        {
            return await appDbContext.Reviews.Include(r => r.User).FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task UpdateReview(Review review)
        {
            appDbContext.Entry(review).State = EntityState.Modified;
        }
    }
}
