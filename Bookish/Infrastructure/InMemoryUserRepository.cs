using Application;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class InMemoryUserRepository : IUserRepository
    {
        private ICollection<RegularUser> _users;
        public InMemoryUserRepository()
        {
            _users = new List<RegularUser>
            {
                new RegularUser {Id = 0, Name = "Ana", Email = "ana@gmail.com", Password = "1234"},
                new RegularUser {Id = 1, Name = "Vlad", Email = "vlad@gmail.com", Password = "1234"},
            };
        }

        public RegularUser Login(string email, string password)
        {
            var user = _users.FirstOrDefault(user => user.Email.Equals(email) && user.Password.Equals(password));
            return user;
        }
    }
}
