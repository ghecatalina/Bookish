using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Queries.GetBooks
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, IEnumerable<BookViewModel>>
    {
        private readonly IBookRepository _repository;
        public GetBooksQueryHandler(IBookRepository repository)
        {
            _repository = repository;
        }
        public Task<IEnumerable<BookViewModel>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var result = _repository
                .GetAll()
                .Select(book => new BookViewModel
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                });
            return Task.FromResult(result);
        }
    }
}
