using System.Linq.Expressions;

namespace ASPApp.Dal.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>?> GetAllAsync();
        Task<T?> GetByIdAsync(params object[] id);
        Task<T?> AddAsync(T? entity);
        void Remove(T entity);
        Task<bool> RemoveAsync(params object[] id);
        void Update(T entity);
        Task<bool> UpdateAsync(params object[] id);
        Task SaveChangesAsync();
        Task<IEnumerable<T>> GetWithIncludeAsync(params Expression<Func<T, object>>[] includeProperties);
    }
}
