using Application;
using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        private AppDbContext _appDbContext
        {
            get { return _appDbContext as AppDbContext; }
        }
        public void ChangeUserDetails(string userId, string username, string password)
        {
            
        }

        public async Task<User> LoginUser(string email, string password)
        {
            var user = GetAll().Result.Where(u => u.Email == email && u.Password == password).SingleOrDefault();
            return await Task.FromResult(user);
        }
    }
}
