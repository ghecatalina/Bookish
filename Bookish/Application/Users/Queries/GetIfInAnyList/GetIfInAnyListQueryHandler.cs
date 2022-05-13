using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetIfInAnyList
{
    public class GetIfInAnyListQueryHandler : IRequestHandler<GetIfInAnyListQuery, BListType>
    {
        private readonly IUserRepository _repository;
        public GetIfInAnyListQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<BListType> Handle(GetIfInAnyListQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdWithBookLists(request.UserId);
            foreach (var book in user.Read.Books)
            {
                if (book.Id == request.BookId)
                    return new BListType() { BookListType = "read" };
            }
            foreach (var book in user.CurrentlyReading.Books)
            {
                if (book.Id == request.BookId)
                    return new BListType() { BookListType = "currentlyreading" };
            }
            foreach (var book in user.WantToRead.Books)
            {
                if (book.Id == request.BookId)
                    return new BListType() { BookListType = "wanttoread" };
            }
            return new BListType() { BookListType = "none" };
        }
    }
}
