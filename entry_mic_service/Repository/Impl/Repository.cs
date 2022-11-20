using entry_mic_service.Data;
using entry_mic_service.Data.Model;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace entry_mic_service.Repository.Impl
{
    public abstract class Repository<T> : IRepository<T> where T : Base
    {
        private readonly Context _context;

        public Repository(Context context)
        {
            _context = context;
        }

        public void Add(T data)
        {
            _context.GetCollection<T>().InsertOneAsync(data);
        }

        public void Delete(T data)
        {
            _context.GetCollection<T>().DeleteOneAsync(data.Id);
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _context.GetCollection<T>().Find(predicate).ToList();
        }

        public T? Get(object id)
        {
            return _context.GetCollection<T>().Find(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _context.GetCollection<T>().Find(_ => true).ToList();
        }

        public int SaveChanges()
        {
            return 0;
        }

        public void Update(T data)
        {
            _context.GetCollection<T>().ReplaceOneAsync(x => x.Id == data.Id, data);
        }
    }
}
