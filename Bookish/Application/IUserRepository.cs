using Domain;
using System;

namespace Application
{
    public interface IUserRepository
    {
        RegularUser Login(string email, string password);
    }
}
