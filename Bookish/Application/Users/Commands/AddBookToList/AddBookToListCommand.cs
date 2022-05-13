using Application.Users.Queries;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.AddBookToList
{
    public class AddBookToListCommand : IRequest<BListType>
    {
        public Guid UserId { get; set; }
        public int BookId { get; set; }
        public string FromListType { get; set; }
        public string ToListType { get; set; }
    }
}
