namespace Domain
{
    public class BookList : BaseEntity
    {
        public int UserId { get; set; }
        public ListType ListType { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
