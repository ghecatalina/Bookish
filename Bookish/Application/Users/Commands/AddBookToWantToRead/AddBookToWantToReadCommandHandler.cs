using Application.Interfaces;
using MediatR;

namespace Application.Users.Commands.AddBookToWantToRead
{
    public class AddBookToWantToReadCommandHandler : IRequestHandler<AddBookToWantToReadCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;
        public AddBookToWantToReadCommandHandler(IUserRepository userRepository, IBookRepository bookRepository)
        {
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }

        public async Task<Unit> Handle(AddBookToWantToReadCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdWithBookLists(request.UserId);
            var book = await _bookRepository.GetById(request.BookId);
            if (user != null && book != null)
            {
                user.WantToRead.Books.Add(book);
            }
            _userRepository.Update(user);
            return Unit.Value;
        }
    }
}
