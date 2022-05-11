namespace Api.Dto
{
    public class ReviewPutPostDto
    {
        public Guid UserId { get; set; }
        public int BookId { get; set; }
        public double Rating { get; set; }
        public string ReviewDescription { get; set; }
    }
}
