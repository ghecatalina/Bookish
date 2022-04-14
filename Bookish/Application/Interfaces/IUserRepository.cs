using Domain;
using System;

namespace Application.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        //Task ChangeUserDetails(string userId, string username, string password);
    }
}
