using System.Linq.Expressions;

namespace ASPApp.Dal.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<T?> GetByIdWithIncludeAsync(Guid id, params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>?> GetWithFiltersAsync(Expression<Func<T, bool>> filterProperties);
        Task<IEnumerable<T>?> GetWithIncludeAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>?> GetAllAsync();
        Task AddAsync(T? entity);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(Guid id);
        Task SaveChangesAsync();
    }
}
