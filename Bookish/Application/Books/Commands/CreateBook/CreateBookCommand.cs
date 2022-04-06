using Domain;
using MediatR;
using System;

namespace Application.Books.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<Book>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string BookCoverImage { get; set; }
    }
}
