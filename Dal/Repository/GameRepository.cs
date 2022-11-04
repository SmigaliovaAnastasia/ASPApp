using ASPApp.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using ASPApp.Domain.Entities;
using ASPApp.Common.Models.Pagination;
using AutoMapper;

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

        public async Task<IEnumerable<T>?> GetAllWithIncludeAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            return await IncludeProperties(includeProperties).ToListAsync();
        }

        public async Task<T?> GetWithFiltersAsync(Expression<Func<T, bool>> filterProperties)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(filterProperties);
        }

        public async Task<PagedResult<TDto>> GetPagedResultAsync<TDto>(PagedRequest<T> request, IMapper mapper, params Expression<Func<T, object>>[] includeProperties) where TDto : class
        {
            var query = IncludeProperties(includeProperties);
            query = request.ApplyFilters(query);
            var list = await request.ApplySortingMethod(query).ToListAsync();
            var total = list.Count();
            var result = mapper.Map<IEnumerable<T>, IEnumerable<TDto>>(list.Skip(request.PageIndex * request.PageSize).Take(request.PageSize));
            return new PagedResult<TDto>(request.PageIndex, request.PageSize, total, result);
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
