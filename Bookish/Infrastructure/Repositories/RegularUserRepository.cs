using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RegularUserRepository : Repository<RegularUser>, IRegularUserRepository
    {
        public RegularUserRepository(AppDbContext context) : base(context)
        {
        }

        private AppDbContext appDbContext
        {
            get { return _context as AppDbContext; }
        }

        public void Update(RegularUser user)
        {
            appDbContext.Update(user);
        }

        public RegularUser? GetByIdWithBookLists(int id)
        {
            return appDbContext.RegularUsers
                .Include(u => u.Read)
                .Include(u => u.CurrentlyReading)
                .Include(u => u.WantToRead)
                .SingleOrDefault(u => u.Id == id);
        }
    }
}
