using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookLists.Queries.GetReadList
{
    public class GetReadListQuery : IRequest<BookList>
    {
    }
}
