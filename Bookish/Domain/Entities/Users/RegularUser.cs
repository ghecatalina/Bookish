using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class RegularUser : User
    {
        public string ProfilePicture { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public BookList? Read { get; set; } = new BookList { ListType = ListType.Read, Books = new List<Book>()};
        public BookList? WantToRead { get; set; } = new BookList { ListType = ListType.WantToRead, Books = new List<Book>() };
        public BookList? CurrentlyReading { get; set; } = new BookList { ListType = ListType.CurrentlyReading, Books=new List<Book>() };
    }
}