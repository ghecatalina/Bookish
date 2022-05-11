using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task AddCategory(Category category);
        Task<Category> GetByName(string name);
        Task<List<Category>> GetAll();
        Task<Category> GetById(int id);
    }
}
