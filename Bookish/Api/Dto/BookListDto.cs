namespace Api.Dto
{
    public class BookListDto
    {
        public int id { get; set; }
        public List<BookGetDto> Books { get; set; }
    }
}
