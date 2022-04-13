using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Unit>
    {
        private readonly IUserRepository _repository;
        public CreateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User { Email = request.Email, Name = request.Name, Password = request.Password};
            await _repository.Add(user);

            return Unit.Value;
        }
    }
}
