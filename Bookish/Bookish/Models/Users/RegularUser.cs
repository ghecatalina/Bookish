using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookish.Models
{
    public class RegularUser : User
    {
        
        public string ProfilePicture { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public BookList Read { get; set; }
        public BookList CurrentlyReading { get; set; }
        public BookList WantToRead { get; set; }
    }
}
