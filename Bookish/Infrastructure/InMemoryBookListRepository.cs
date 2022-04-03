using Application;
using Domain;

namespace Infrastructure
{
    public class InMemoryBookListRepository : IBookListRepository
    {
        public void AddBookToCurrentlyReading(RegularUser user, Book book)
        {
            user.CurrentlyReading.UserId = user.Id;
            user.CurrentlyReading.BookId = book.Id;
            user.CurrentlyReading.Books.Add(book);
        }

        public void AddBookToRead(RegularUser user, Book book)
        {
            user.Read.UserId = user.Id;
            user.Read.BookId = book.Id;
            user.Read.Books.Add(book);
        }

        public void AddBookToWantToRead(RegularUser user, Book book)
        {
            user.WantToRead.UserId = user.Id;
            user.WantToRead.BookId = book.Id;
            user.WantToRead.Books.Add(book);
        }
    }
}
