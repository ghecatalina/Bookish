using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetBookList
{
    public class GetBookListQuery : IRequest<ICollection<Book>>
    {
        public Guid UserId { get; set; }
        public string ListType { get; set; }
    }
}
