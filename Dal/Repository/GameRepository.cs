using ASPApp.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using ASPApp.Domain.Entities;
using ASPApp.Common.Models.Pagination;
using AutoMapper;
using NuGet.Packaging;

namespace ASPApp.Dal.Repository
{
    public class GameRepository : IRepository<Game>
    {
        private DbContext _context { get; set; }
        public GameRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<Game?> GetByIdAsync(Guid id)
        {
            return await _context.Set<Game>().FindAsync(id);
        }

        public async Task<Game?> GetByIdWithIncludeAsync(Guid id, params Expression<Func<Game, object>>[] includeProperties)
        {
            var query = IncludeProperties(includeProperties);
            return await query.SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Game>?> GetAllAsync()
        {
            return await _context.Set<Game>().ToListAsync();
        }

        public async Task<IEnumerable<Game>?> GetAllWithIncludeAsync(params Expression<Func<Game, object>>[] includeProperties)
        {
            return await IncludeProperties(includeProperties).ToListAsync();
        }

        public async Task<Game?> GetWithFiltersAsync(Expression<Func<Game, bool>> filterProperties)
        {
            return await _context.Set<Game>().FirstOrDefaultAsync(filterProperties);
        }

        public async Task<PagedResult<TDto>> GetPagedResultAsync<TDto>(PagedRequest<Game> request, IMapper mapper, params Expression<Func<Game, object>>[] includeProperties) where TDto : class
        {
            var query = IncludeProperties(includeProperties);
            query = request.ApplyFilters(query);
            var list = await request.ApplySortingMethod(query).ToListAsync();
            var total = list.Count();
            var result = mapper.Map<IEnumerable<Game>, IEnumerable<TDto>>(list.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize));
            return new PagedResult<TDto>(request.PageIndex, request.PageSize, total, result);
        }

        public async Task AddAsync(Game? entity)
        {
            if (entity != null)
            {
                await _context.Set<Game>().AddAsync(entity);
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

        public IQueryable<Game> IncludeProperties(params Expression<Func<Game, object>>[] includeProperties)
        {
            IQueryable<Game> query = _context.Set<Game>();
            includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).ToList();
            return query;
        }

        public async Task<Game?> ConnectRelatedEntities(Guid id, ICollection<Guid> ids)
        {
            var relatedEntities = await _context.Set<Genre>().Where(e => ids.Contains(e.Id)).ToListAsync();
            var entity = await GetByIdWithIncludeAsync(id, g => g.Genres);
            if (entity != null)
            {
                entity.Genres = entity.Genres.Intersect(relatedEntities).ToList();
                entity.Genres.AddRange(relatedEntities.Except(entity.Genres));
            }
            return entity;
        }
    }
}
