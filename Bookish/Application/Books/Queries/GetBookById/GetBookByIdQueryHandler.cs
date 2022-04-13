using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Queries.GetBookById
{
    internal class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly IBookRepository _repository;
        public GetBookByIdQueryHandler(IBookRepository repository)
        {
            _repository = repository;
        }
        public Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = _repository.GetById(request.Id);
            return book;
        }
    }
}
