namespace Api.Dto
{
    public class UpdateUserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ProfilePicture { get; set; }
        public string Password { get; set; }
    }
}
