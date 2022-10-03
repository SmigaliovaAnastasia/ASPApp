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
        public async Task AddAsync(T? entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            await _context.Set<T>().AddAsync(entity);
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

        public void Remove(T? entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            _context.Set<T>().Remove(entity);
        }

        public async Task RemoveAsync(params object[] id)
        {
            var entity = await GetByIdAsync(id);
            Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(T? entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task UpdateAsync(params object[] id)
        {
            var entity = await GetByIdAsync(id);
            Update(entity);
        }
    }
}
