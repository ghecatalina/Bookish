using Application;
using Application.Interfaces;
using Domain;

namespace Infrastructure
{
    public class BookListRepository : Repository<BookList>, IBookListRepository
    {
        public BookListRepository(AppDbContext context) : base(context)
        {
        }

        public void AddBookToCurrentlyReading(RegularUser user, Book book)
        {
            user.CurrentlyReading.Books.Add(book);
        }

        public void AddBookToRead(RegularUser user, Book book)
        {
            user.Read.Books.Add(book);
        }

        public void AddBookToWantToRead(RegularUser user, Book book)
        {
            user.WantToRead.Books.Add(book);
        }
    }
}
