using JailooCRM.DAL.Common;

namespace JailooCRM.DAL
{
    public interface IRepository<T, TKey> where T : BaseEntity<TKey>
    {
        public Task<T> AddAsync(T item); // C
        public Task<List<T>> AddAllAsync(IEnumerable<T> items);
        public Task<List<T>> GetAllAsync(); // R
        public Task <T> GetByIdAsync(TKey id); // R
        public Task Update(T item); // U
        public Task Delete(T item); // D
        public Task DeleteById(TKey id); // D
    }
}
