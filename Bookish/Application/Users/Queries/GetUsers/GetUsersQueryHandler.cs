using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUsers
{
    internal class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserViewModel>>
    {
        private readonly IUserRepository _repository;
        public GetUsersQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public Task<IEnumerable<UserViewModel>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var result = _repository
               .GetAll()
               .Select(user => new UserViewModel
               {
                   Id = user.Id,
                   Name = user.Name,
                   Email = user.Email,
               });
            return Task.FromResult(result);
        }
    }
}
