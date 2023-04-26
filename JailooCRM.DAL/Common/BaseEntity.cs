namespace JailooCRM.DAL.Common
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateTimeAdded { get; set; }
        public DateTime DateTimeUpdated { get; set; }

        public static bool operator == (BaseEntity<TKey> left, BaseEntity<TKey> right)
        {
            return left.Id.Equals(right.Id);
        }

        public static bool operator != (BaseEntity<TKey> left, BaseEntity<TKey> right)
        {
            return !left.Id.Equals(right.Id);
        }
    }
}
