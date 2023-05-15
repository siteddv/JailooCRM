using JailooCRM.DAL.Common;

namespace JailooCRM.DAL
{
    /// <summary>
    /// Part of <see cref="DAL.Department"/>. For example, kitchen consists of kyrgyz cusine, chinese cousine and so on
    /// </summary>
    public class Subcategory : BaseEntity<int>
    {
        public string Name { get; set; }
        public Specialization Specialization { get; set; }

        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<Product> Products { get; set; }

    }
}