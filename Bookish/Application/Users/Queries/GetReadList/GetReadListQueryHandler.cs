using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetReadList
{
    public class GetReadListQueryHandler : IRequestHandler<GetReadListQuery, BookList>
    {
        private readonly IUserRepository _repository;
        public GetReadListQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<BookList> Handle(GetReadListQuery request, CancellationToken cancellationToken)
        {
            var books = await _repository.GetReadList(request.Id);
            return books;
        }
    }
}
