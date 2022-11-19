using auth_mic_service.Data.Model;
using System.Linq.Expressions;

namespace auth_mic_service.Repository
{
    public interface IRepository<T> where T : Base
    {
        T? Get(object Id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
        void Add(T data);
        void Update(T data);
        void Delete(T data);
    }
}
