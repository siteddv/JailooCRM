using JailooCRM.DAL.Common;

namespace JailooCRM.DAL.Response
{
    public class SubcategoryResponse : EntityResponse<int>
    {
        public SubcategoryResponse(Subcategory entity, int statusCode, string message, bool isSuccess) 
            : base(entity, statusCode, message, isSuccess)
        {
            Name = entity.Name;
            Specialization = entity.Specialization;
        }

        public string Name { get; set; }
        public Specialization Specialization { get; set; }
    }
}
