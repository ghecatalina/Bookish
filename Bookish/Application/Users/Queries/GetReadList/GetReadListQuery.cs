using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetReadList
{
    public class GetReadListQuery : IRequest<BookList>
    {
        public Guid Id { get; set; }
    }
}
