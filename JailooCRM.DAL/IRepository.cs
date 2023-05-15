using JailooCRM.DAL.Common;

namespace JailooCRM.DAL
{
    public interface IRepository<T, TKey> where T : BaseEntity<TKey>
    {
        public Task<T> AddAsync(T item); // C
        public Task<List<T>> AddAllAsync(IEnumerable<T> items);
        public List<T> GetAll(); // R
        public T GetById(TKey id); // R
        public void Update(T item); // U
        public void Delete(T item); // D
        public void DeleteById(TKey id); // D
    }
}
