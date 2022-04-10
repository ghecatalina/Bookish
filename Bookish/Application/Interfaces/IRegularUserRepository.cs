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
        RegularUser? GetByIdWithBookLists(int id);
        void Update(RegularUser user);
    }
}
