using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.AddBookToCurrentlyReading
{
    public class AddBookToCurrentlyReadingCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public int BookId { get; set; }
    }
}
