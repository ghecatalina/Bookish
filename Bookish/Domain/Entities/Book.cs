namespace Domain
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string BookCoverImage { get; set; }
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
