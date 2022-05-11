using Domain;
using System;

namespace Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdWithBookLists(Guid id);
        Task<BookList> GetReadList(Guid id);
        Task<BookList> GetWantToReadList(Guid id);
        Task<BookList> GetCurrentlyReadingList(Guid id);
        void Update(User user);
        Task<User> GetById(Guid id);
        Task<List<User>> GetAll();
        //Task ChangeUserDetails(string userId, string username, string password);
    }
}
