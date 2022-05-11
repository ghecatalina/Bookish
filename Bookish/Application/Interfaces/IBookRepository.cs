using Domain;

namespace Application.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<Book> GetBookById(int id);
    }
}
