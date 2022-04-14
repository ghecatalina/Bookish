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

        public async Task<RegularUser?> GetByIdWithBookLists(int id)
        {
            return await appDbContext.RegularUsers
                .Include(u => u.Read)
                .Include(u => u.Read.Books)
                .Include(u => u.CurrentlyReading)
                .Include(u => u.CurrentlyReading.Books)
                .Include(u => u.WantToRead)
                .Include(u => u.WantToRead.Books)
                .SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<BookList> GetReadList(int id)
        {
            var user = await appDbContext.RegularUsers
                .Include(u => u.Read)
                .Include(u => u.Read.Books)
                .SingleOrDefaultAsync(u => u.Id == id);
            return user.Read;
        }
    }
}
