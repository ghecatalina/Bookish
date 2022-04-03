namespace Domain
{
    public class BookList
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public ListType ListType { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
