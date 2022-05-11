using Application;
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext context, UserManager<User> userManager)
        {
            _appDbContext = context;
            _userManager = userManager;
        }

        public async Task<List<User>> GetAll()
        {
            var users = _userManager.Users.ToListAsync();
            return await users;
        }

        public async Task<User> GetById(Guid id)
        {
            var user = _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            return await user;
        }

        public async Task<User?> GetByIdWithBookLists(Guid id)
        {
            var user = _userManager.Users
                .Include(u => u.Read)
                .ThenInclude(b => b.Books)
                .Include(u => u.CurrentlyReading)
                .ThenInclude(b => b.Books)
                .Include(u => u.WantToRead)
                .ThenInclude(b => b.Books)
                .FirstOrDefaultAsync(x => x.Id == id);
            return await user;
        }

        public async Task<BookList> GetCurrentlyReadingList(Guid id)
        {
            var booklist = _userManager.Users
                .Include(u => u.CurrentlyReading)
                .ThenInclude(u => u.Books)
                .FirstOrDefaultAsync(u => u.Id == id).Result.CurrentlyReading;
            return await Task.FromResult(booklist);
        }

        public async Task<BookList> GetReadList(Guid id)
        {
            var booklist = _userManager.Users
                .Include(u => u.Read)
                .ThenInclude(u => u.Books)
                .FirstOrDefaultAsync(u => u.Id == id).Result.Read;
            return await Task.FromResult(booklist);
        }

        public async Task<BookList> GetWantToReadList(Guid id)
        {
            var booklist = _userManager.Users
                .Include(u => u.WantToRead)
                .ThenInclude(u => u.Books)
                .FirstOrDefaultAsync(u => u.Id == id).Result.WantToRead;
            return await Task.FromResult(booklist);
        }

        public void Update(User user)
        {
            _userManager.UpdateAsync(user);
        }
    }
}