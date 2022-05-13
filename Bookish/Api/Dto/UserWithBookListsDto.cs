namespace Api.Dto
{
    public class UserWithBookListsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<BookGetDto> Read { get; set; }
        public List<BookGetDto> CurrentlyReading { get; set; }
        public List<BookGetDto> WantToRead { get; set; }
    }
}
