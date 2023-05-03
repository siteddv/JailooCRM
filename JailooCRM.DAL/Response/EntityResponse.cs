using JailooCRM.DAL.Common;

namespace JailooCRM.DAL.Response
{
    public class EntityResponse<T> : Response
    {
        private const string dateFormat = "dd/MM/yyyy HH:mm:ss zz";
        public EntityResponse(BaseEntity<T> entity, int statusCode, string message, bool isSuccess) 
            : base(statusCode, message, isSuccess)
        {
            Id = entity.Id;
            DateTimeAdded = entity.DateTimeAdded.ToString(dateFormat);
            DateTimeUpdated = entity.DateTimeUpdated.ToString(dateFormat);
        }

        public T Id { get; set; }
        public string DateTimeAdded { get; set; }
        public string DateTimeUpdated { get; set; }
    }
}
