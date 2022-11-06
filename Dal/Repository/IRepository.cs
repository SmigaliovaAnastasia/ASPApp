using ASPApp.Common.Models.Pagination;
using ASPApp.Domain.Entities;
using ASPApp.Migrations;
using AutoMapper;
using System.Linq.Expressions;

namespace ASPApp.Dal.Repository
{
    public interface IRepository<T> where T : class, IBaseEntity 
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<T?> GetByIdWithIncludeAsync(Guid id, params Expression<Func<T, object>>[] includeProperties);
        Task<T?> GetWithFiltersAsync(Expression<Func<T, bool>> filterProperties);
        Task<IEnumerable<T>?> GetAllWithIncludeAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>?> GetAllAsync();
        Task<PagedResult<TDto>>  GetPagedResultAsync<TDto>(PagedRequest<T> request, IMapper mapper, params Expression<Func<T, object>>[] includeProperties) where TDto : class;
        Task AddAsync(T? entity);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(Guid id);
        Task SaveChangesAsync();
        Task<Game?> ConnectRelatedEntities(Guid id, ICollection<Guid> ids);
    }
}
