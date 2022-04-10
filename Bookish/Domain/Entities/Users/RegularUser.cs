namespace Domain
{
    public class RegularUser : User
    {
        public string ProfilePicture { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public BookList? Read { get; set; } 
        public BookList? WantToRead { get; set; }
        public BookList? CurrentlyReading { get; set; }
    }
}