using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Queries.GetBooks
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, IEnumerable<Book>>
    {
        private readonly IBookRepository _repository;
        public GetBooksQueryHandler(IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Book>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}
