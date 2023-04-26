using JailooCRM.DAL.Common;

namespace JailooCRM.DAL
{
    public class Subcategory : BaseEntity<int>
    {
        public string Name { get; set; }
        public Specialization Specialization { get; set; }

        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<Product> Products { get; set; }

    }
}