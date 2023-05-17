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

        public async Task Delete(T item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

        public async Task DeleteById(TKey id)
        {
            T entity = await GetByIdAsync(id);

            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(TKey id)
        {
            T item = await _dbSet
                .FirstOrDefaultAsync(obj => obj.Id.Equals(id));

            return  item == null 
                ? throw new ArgumentNullException(nameof(id), $"Entity not found by id {id}") 
                : item;
        }

        public async Task Update(T item)
        {
            item.DateTimeUpdated = DateTime.UtcNow;

            _dbSet.Update(item);

            _context.SaveChanges();
        }
    }
}
