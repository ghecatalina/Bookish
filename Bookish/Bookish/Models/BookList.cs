using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookish.Models
{
    public class BookList
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public int ListType { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
