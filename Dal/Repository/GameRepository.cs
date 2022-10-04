using ASPApp.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Linq;
namespace ASPApp.Dal.Repository
{
    public class GameRepository<T> : IRepository<T> where T : class
    {
        private DbContext _context { get; set; }
        public GameRepository(DbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T? entity)
        {
            if (entity != null)
            {
                await _context.Set<T>().AddAsync(entity);
            }
        }

        public async Task<T?> GetByIdAsync(params object[] id)
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

        public async Task<T?> GetWithFilter(Expression<Func<T, bool>> filterProperties)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(filterProperties);
        }

        public async Task RemoveAsync(params object[] id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                throw new EntryNotFoundException("The game you are deleting doesn't exist");
            }
            _context.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(params object[] id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                throw new EntryNotFoundException("The game you are updating doesn't exist");
            }
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
