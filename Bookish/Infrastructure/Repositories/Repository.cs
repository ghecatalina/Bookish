using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _entities;

        public Repository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entities = context.Set<T>();
        }
        
        public async Task Add(T entity)
        {
           await _entities.AddAsync(entity);
           await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Delete(int id)
        {
            var entity =await _entities.FindAsync(id);
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
