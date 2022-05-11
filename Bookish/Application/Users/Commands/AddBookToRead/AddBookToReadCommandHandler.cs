using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.AddBookToReadList
{
    public class AddBookToReadCommandHandler : IRequestHandler<AddBookToReadCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;
        public AddBookToReadCommandHandler(IUserRepository userRepository, IBookRepository bookRepository)
        {
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }
        public async Task<Unit> Handle(AddBookToReadCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdWithBookLists(request.UserId);
            var book = await _bookRepository.GetById(request.BookId);
            if (user != null && book != null)
            {
                user.Read.Books.Add(book);
            }
            _userRepository.Update(user);
            return Unit.Value;
        }
    }
}
