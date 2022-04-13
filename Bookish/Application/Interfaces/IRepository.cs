using Domain;
using System.Linq.Expressions;

namespace Application.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        Task Delete(int id);
        Task Save();
    }
}
