using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetIfInAnyList
{
    public class GetIfInAnyListQuery : IRequest<BListType>
    {
        public int BookId { get; set; }
        public Guid UserId { get; set; }
    }
}
