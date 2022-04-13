using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetRegularUserById
{
    public class GetRegularUserByIdQueryHandler : IRequestHandler<GetRegularUserByIdQuery, RegularUser>
    {
        private readonly IRegularUserRepository _repository;
        public GetRegularUserByIdQueryHandler(IRegularUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<RegularUser> Handle(GetRegularUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdWithBookLists(request.Id);
        }
    }
}
