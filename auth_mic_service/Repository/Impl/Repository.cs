using auth_mic_service.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace auth_mic_service.Repository.Impl
{
    public abstract class Repository<T> : IRepository<T> where T : Base
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public void Add(T data)
        {
            _context.Set<T>().Add(data);
        }

        public void Delete(T data)
        {
            _context.Set<T>().Remove(data);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _context.Set<T>().Where(predicate);
            return query;
        }

        public T? Get(object Id)
        {
            return _context.Set<T>().Find(Id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _context.Set<T>();
            return query;
        }

        public void Update(T data)
        {
            _context.Entry(data).State = EntityState.Modified;
        }
    }
}
