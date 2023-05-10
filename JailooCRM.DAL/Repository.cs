using JailooCRM.DAL.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace JailooCRM.DAL
{
    public class Repository<T,TKey> : IRepository<T,TKey> 
        where T : BaseEntity<TKey>
    {
        protected readonly PgContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(PgContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();

            if (_dbSet == default(DbSet<T>))
                throw new ArgumentNullException(nameof(DbSet<T>));
        }

        public async Task<T> AddAsync(T item)
        {
            item.DateTimeAdded = DateTime.UtcNow;
            item.DateTimeUpdated = DateTime.UtcNow;
            EntityEntry<T> entity = await _dbSet.AddAsync(item);
            T result = entity.Entity;

            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<List<T>> AddAllAsync(IEnumerable<T> items)
        {
            List<T> result = new List<T>();

            foreach(T item in items)
            {
                item.DateTimeAdded = DateTime.UtcNow;
                item.DateTimeUpdated = DateTime.UtcNow;
                EntityEntry<T> entityEntry = await _dbSet.AddAsync(item);
                T entity = entityEntry.Entity;
                result.Add(entity);
            }

            await _context.SaveChangesAsync();
            return result;
        }

        public void Delete(T item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(TKey id)
        {
            T item = _dbSet
                .FirstOrDefault(obj => obj.Id.Equals(id));

            return item;
        }

        private bool Find(T item, TKey id)
        {
            return item.Id.Equals(id);
        }

        public void Update(T item)
        {
            item.DateTimeUpdated = DateTime.UtcNow;

            _dbSet.Update(item);

            _context.SaveChanges();
        }
    }
}
