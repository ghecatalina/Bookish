namespace Api.Dto
{
    public class ReviewGetDto
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Photo { get; set; }
        public double Rating { get; set; }
        public string ReviewDescription { get; set; }
    }
}
