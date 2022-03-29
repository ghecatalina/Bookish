using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookish.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string ReviewDescription { get; set; }
        public double Rating { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int BookId { get; set; }
        public  Book Book { get; set; }
    }
}
