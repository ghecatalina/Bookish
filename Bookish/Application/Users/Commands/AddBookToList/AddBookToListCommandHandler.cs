using Application.Interfaces;
using Application.Users.Queries;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.AddBookToList
{
    public class AddBookToListCommandHandler : IRequestHandler<AddBookToListCommand, BListType>
    {
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;
        public AddBookToListCommandHandler(IUserRepository userRepository, IBookRepository bookRepository)
        {
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }
        public async Task<BListType> Handle(AddBookToListCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdWithBookLists(request.UserId);
            var book = await _bookRepository.GetBookById(request.BookId);
            if (request.FromListType == request.ToListType)
            {
                 if (request.FromListType == "read")
                {
                    user.Read.Books.Remove(book);
                    await _userRepository.Save();
                }
                else if (request.FromListType == "currentlyreading")
                {
                    user.CurrentlyReading.Books.Remove(book);
                    await _userRepository.Save();
                }
                else if (request.ToListType == "wanttoread")
                {
                    user.CurrentlyReading.Books.Remove(book);
                    await _userRepository.Save();
                }
                return new BListType() { BookListType = "none" };
            }
            if (request.ToListType == "read")
            {
                user.Read.Books.Add(book);
            }else if (request.ToListType == "currentlyreading")
            {
                user.CurrentlyReading.Books.Add(book);
            }else if (request.ToListType == "wanttoread")
            {
                user.WantToRead.Books.Add(book);
            }
            if (request.FromListType == "none")
            {
                await _userRepository.Save();
                return new BListType() { BookListType = request.ToListType };
            }
            else if (request.FromListType == "read")
            {
                user.Read.Books.Remove(book);
                await _userRepository.Save();
                return new BListType() { BookListType = request.ToListType };
            }
            else if (request.FromListType == "currentlyreading")
            {
                user.CurrentlyReading.Books.Remove(book);
                await _userRepository.Save();
                return new BListType() { BookListType = request.ToListType };
            }
            else if (request.ToListType == "wanttoread")
            {
                user.WantToRead.Books.Remove(book);
                await _userRepository.Save();
                return new BListType() { BookListType = request.ToListType };
            }

            //_userRepository.UpdateUser(user);
            await _userRepository.Save();
            return new BListType() { BookListType = request.ToListType };
        }
    }
}
