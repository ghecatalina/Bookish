using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUsers
{
    internal class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<User>>
    {
        private readonly IUserRepository _repository;
        public GetUsersQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public Task<List<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var result = _repository.GetAll();
            return result;
        }
    }
}
