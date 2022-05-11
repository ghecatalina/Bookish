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
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;
        public CreateBookCommandHandler(IBookRepository bookRepository, ICategoryRepository categoryRepository)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<Book> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByName(request.CategoryName);
            var book = new Book { Title = request.Title, Author = request.Author, BookCoverImage = request.BookCoverImage, Description = request.Description, Category = category };
            await _bookRepository.Add(book);

            return book;
        }
    }
}
