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
        public void Add(T? entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            _context.Set<T>().Add(entity);
        }

        public T? GetById(params Object[] id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T>? GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).ToList();
        }

        public void Remove(T? entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            _context.Set<T>().Remove(entity);
        }

        public void Remove(params object[] id)
        {
            var entity = GetById(id);
            Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T? entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Update(params object[] id)
        {
            var entity = GetById(id);
            Update(entity);
        }
    }
}
