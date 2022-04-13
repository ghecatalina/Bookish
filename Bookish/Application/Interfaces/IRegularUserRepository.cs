using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRegularUserRepository : IRepository<RegularUser>
    {
        Task<RegularUser?> GetByIdWithBookLists(int id);
        Task<BookList> GetReadList(int id);
    }
}
