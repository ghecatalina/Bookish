namespace Domain
{
    public class RegularUser : User
    {
        public string ProfilePicture { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public BookList? Read { get; set; } = new BookList { ListType = ListType.Read};
        public BookList? WantToRead { get; set; } = new BookList { ListType = ListType.WantToRead };
        public BookList? CurrentlyReading { get; set; } = new BookList { ListType = ListType.CurrentlyReading };
    }
}