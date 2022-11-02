using ASPApp.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using ASPApp.Domain.Entities;

namespace ASPApp.Dal.Repository
{
    public class GameRepository<T> : IRepository<T> where T : class, IBaseEntity
    {
        private DbContext _context { get; set; }
        public GameRepository(DbContext context)
        {
            _context = context;
        }
 
        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T?> GetByIdWithIncludeAsync(Guid id, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = IncludeProperties(includeProperties);
            return await query.SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<T>?> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>?> GetWithIncludeAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            return await IncludeProperties(includeProperties).ToListAsync();
        }

        public async Task<IEnumerable<T>?> GetWithFiltersAsync(Expression<Func<T, bool>> filterProperties)
        {
            return await _context.Set<T>().Where(filterProperties).ToListAsync();
        }

        public async Task AddAsync(T? entity)
        {
            if (entity != null)
            {
                await _context.Set<T>().AddAsync(entity);
            }
        }

        public async Task RemoveAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                throw new EntryNotFoundException("The entity you are deleting doesn't exist");
            }
            _context.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                throw new EntryNotFoundException("The entity you are updating doesn't exist");
            }
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<T> IncludeProperties(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).ToList();
            return query;
        }
    }
}
