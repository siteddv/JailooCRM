namespace JailooCRM.DAL
{
    public class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateTimeAdded { get; set; }
        public DateTime DateTimeUpdated { get; set; }
    }
}
