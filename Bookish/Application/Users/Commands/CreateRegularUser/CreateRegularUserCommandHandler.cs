using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateRegularUser
{
    internal class CreateRegularUserCommandHandler : IRequestHandler<CreateRegularUserCommand, RegularUser>
    {
        private readonly IUserRepository _repository;
        public CreateRegularUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public Task<RegularUser> Handle(CreateRegularUserCommand request, CancellationToken cancellationToken)
        {
            var user = new RegularUser 
            { 
                Email = request.Email, 
                Name = request.Name, 
                Password = request.Password, 
                ProfilePicture = request.ProfilePicture,
                Read = new BookList { ListType = ListType.Read , Books = new List<Book>()},
                CurrentlyReading = new BookList { ListType = ListType.CurrentlyReading, Books = new List<Book>() },
                WantToRead = new BookList { ListType = ListType.WantToRead, Books = new List<Book>() },
            };
            _repository.Add(user);

            return Task.FromResult(user);
        }
    }
}
