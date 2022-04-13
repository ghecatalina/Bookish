using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.AddBookToReadList
{
    public class AddBookToReadCommand : IRequest<Unit>
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
    }
}
