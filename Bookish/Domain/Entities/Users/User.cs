using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class User : IdentityUser<Guid>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
