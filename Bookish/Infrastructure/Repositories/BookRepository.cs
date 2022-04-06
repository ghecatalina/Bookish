using Application;
using Application.Interfaces;
using Domain;

namespace Infrastructure
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }
    }
}
