using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace ASPApp.Dal.Repository
{
    public class GameRepository<T> : IRepository<T> where T : class
    {
        private DbContext _context { get; set; }
        public GameRepository(DbContext context)
        {
            _context = context;
        }
        public async Task<T?> AddAsync(T? entity)
        {
            if (entity != null)
            {
                await _context.Set<T>().AddAsync(entity);
            }
            return entity;
        }

        public async Task<T?> GetByIdAsync(params Object[] id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>?> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<IEnumerable<T>> GetWithIncludeAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).ToList();
            return await query.ToListAsync();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<bool> RemoveAsync(params object[] id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                return false;
            }
            Remove(entity);
            return true;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task<bool> UpdateAsync(params object[] id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                return false;
            }
            Update(entity);
            return true;
        }
    }
}
