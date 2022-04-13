namespace Domain
{
    public class BookList : BaseEntity
    {
        public ListType ListType { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
