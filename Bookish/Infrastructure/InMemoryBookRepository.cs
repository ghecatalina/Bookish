using Application;
using Domain;

namespace Infrastructure
{
    public class InMemoryBookRepository : IBookRepository
    {
        private ICollection<Book> _books;

        public InMemoryBookRepository()
        {
            _books = new List<Book>
            {
                new Book {Id=0, Title="Departe de lumea dezlantuita", Author="Thomas Hardy", Description="descriere", Genre="fictiune"},
                new Book {Id=1, Title="O viata marunta", Author="Hanya Yanagihara", Description="descriere", Genre="fictiune"},
                new Book {Id=2, Title="Flori pentru Algernon", Author="Daniel Keyes", Description="descriere", Genre="fictiune"},
                new Book {Id=3, Title="Oameni anxiosi", Author="Fredrik Backman", Description="descriere", Genre="fictiune"},
                new Book {Id=4, Title="Noi", Author="David Nicholls", Description="descriere", Genre="fictiune"},
                new Book {Id=5, Title="Invitatie la vals", Author="Mihail Drumes", Description="descriere", Genre="fictiune"}
            };
        }

        public Book GetBook(int id)
        {
            return _books.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _books;
        }
    }
}
