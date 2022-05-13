namespace Api.Dto
{
    public class AddToBookListDto
    {
        public Guid UserId { get; set; }
        public int BookId { get; set; }
        public string FromListType { get; set; }
        public string ToListType { get; set; }
    }
}
