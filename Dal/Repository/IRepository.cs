using System.Linq.Expressions;

namespace ASPApp.Dal.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>?> GetAllAsync();
        Task<T?> GetByIdAsync(params object[] id);
        Task<T?> GetWithFilterAsync(Expression<Func<T, bool>> filterProperties);
        Task AddAsync(T? entity);
        Task RemoveAsync(params object[] id);
        Task UpdateAsync(params object[] id);
        Task SaveChangesAsync();
        Task<IEnumerable<T>> GetWithIncludeAsync(params Expression<Func<T, object>>[] includeProperties);
    }
}
