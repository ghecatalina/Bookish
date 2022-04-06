using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBookListRepository : IRepository<BookList>
    {
        void AddBookToRead(RegularUser user, Book book);
        void AddBookToWantToRead(RegularUser user, Book book);
        void AddBookToCurrentlyReading(RegularUser user, Book book);
    }
}
