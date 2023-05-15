using JailooCRM.DAL.Common;

namespace JailooCRM.DAL.Request
{
    public class CreateSubcategoryRequest
    {
        public string Name { get; set; }
        public Specialization Specialization { get; set; }
        public int DepartmentId { get; set; }
    }
}
