using JailooCRM.DAL.Common;

namespace JailooCRM.DAL.DTOs
{
    public class EntityDto<TKey>
    {
        private const string dateFormat = "dd/MM/yyyy HH:mm:ss zz";
        public EntityDto(BaseEntity<TKey> entity)
        {
            Id = entity.Id;
            DateTimeAdded = entity.DateTimeAdded.ToString(dateFormat);
            DateTimeUpdated = entity.DateTimeUpdated.ToString(dateFormat);
        }

        public TKey Id { get; set; }
        public string DateTimeAdded { get; set; }
        public string DateTimeUpdated { get; set; }
    }
}
