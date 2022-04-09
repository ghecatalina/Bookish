namespace Domain
{
    public class Review : BaseEntity
    {
        public string ReviewDescription { get; set; }
        public double Rating { get; set; }
        public int UserId { get; set; }
        public RegularUser User { get; set; }
        public int BookId { get; set; }
        public  Book Book { get; set; }
    }
}
