using System.Linq.Expressions;

namespace ASPApp.Dal.Repository
{
    internal interface IRepository<T> where T : class
    {
        List<T>? GetAll();
        T? GetById(params object[] id);
        void Add(T entity);
        void Remove(T entity);
        void Remove(params object[] id);
        void Update(T entity);
        void Update(params object[] id);
        void Save();
        public IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties);
    }
}
