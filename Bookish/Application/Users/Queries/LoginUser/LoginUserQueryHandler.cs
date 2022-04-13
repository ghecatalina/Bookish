using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.LoginUser
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, User>
    {
        private readonly IUserRepository _repository;
        public LoginUserQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<User> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.LoginUser(request.Email, request.Password);
            return user;
        }
    }
}
