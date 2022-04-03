using Domain;

namespace Application
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        Book GetBook(int id);
    }
}
