using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetBookList
{
    public class GetBookListQueryHandler : IRequestHandler<GetBookListQuery, ICollection<Book>>
    {
        private readonly IUserRepository _userRepository;
        public GetBookListQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ICollection<Book>> Handle(GetBookListQuery request, CancellationToken cancellationToken)
        {
            var user  = await _userRepository.GetByIdWithBookLists(request.UserId);
            if (request.ListType == "read")
            {
                return user.Read.Books;
            }else if (request.ListType == "currentlyreading")
            {
                return user.CurrentlyReading.Books;
            }
            return user.WantToRead.Books;
        }
    }
}
