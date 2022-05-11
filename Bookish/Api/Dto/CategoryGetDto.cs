namespace Api.Dto
{
    public class CategoryGetDto
    {
        public string CategoryName { get; set; }
        public List<BookGetDto> Books { get; set; }
    }
}
