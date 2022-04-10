using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.UpdateRegularUser
{
    public class UpdateRegularUserCommand : IRequest<RegularUser>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ProfilePicture { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public BookList? Read { get; set; }
        public BookList? CurrentlyReading { get; set; }
        public BookList? WantToRead { get; set; }
    }
}
