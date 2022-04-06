using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IBookRepository _repository;
        public CreateBookCommandHandler(IBookRepository repository)
        {
            _repository = repository;
        }
        public Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book { Title = request.Title, Author = request.Author };
            _repository.Add(book);

            return Task.FromResult(book.Id);
        }
    }
}
