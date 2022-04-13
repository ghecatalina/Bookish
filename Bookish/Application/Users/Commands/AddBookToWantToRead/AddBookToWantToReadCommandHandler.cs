using Application.Interfaces;
using MediatR;

namespace Application.Users.Commands.AddBookToWantToRead
{
    public class AddBookToWantToReadCommandHandler : IRequestHandler<AddBookToWantToReadCommand, Unit>
    {
        private readonly IRegularUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;
        public AddBookToWantToReadCommandHandler(IRegularUserRepository userRepository, IBookRepository bookRepository)
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
            await _userRepository.Save();
            return Unit.Value;
        }
    }
}
