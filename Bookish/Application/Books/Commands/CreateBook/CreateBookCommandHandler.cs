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
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Book>
    {
        private readonly IBookRepository _repository;
        public CreateBookCommandHandler(IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task<Book> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book { Title = request.Title, Author = request.Author, BookCoverImage = request.BookCoverImage, Description = request.Description, Genre = request.Genre };
            await _repository.Add(book);

            return book;
        }
    }
}
