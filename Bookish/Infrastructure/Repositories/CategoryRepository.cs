using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;
        public CategoryRepository(AppDbContext context)
        {
            _appDbContext = context;
        }
        public async Task AddCategory(Category category)
        {
            await _appDbContext.Categories.AddAsync(category);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAll()
        {
            return await _appDbContext.Categories
                .Include(c => c.Books.Take(5))
                .ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await _appDbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category> GetByName(string name)
        {
            return await _appDbContext.Categories
                .Include(c => c.Books)
                .FirstOrDefaultAsync(c => c.CategoryName == name);
        }
    }
}
