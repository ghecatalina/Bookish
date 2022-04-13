﻿using Application.Interfaces;
using MediatR;

namespace Application.Users.Commands.AddBookToCurrentlyReading
{
    internal class AddBookToCurrentlyReadingCommandHandler : IRequestHandler<AddBookToCurrentlyReadingCommand, Unit>
    {
        private readonly IRegularUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;
        public AddBookToCurrentlyReadingCommandHandler(IRegularUserRepository userRepository, IBookRepository bookRepository)
        {
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }
        public async Task<Unit> Handle(AddBookToCurrentlyReadingCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdWithBookLists(request.UserId);
            var book = await _bookRepository.GetById(request.BookId);
            if (user != null && book != null)
            {
                user.CurrentlyReading.Books.Add(book);
            }
            await _userRepository.Save();
            return Unit.Value;
        }
    }
}