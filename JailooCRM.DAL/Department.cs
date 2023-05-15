using JailooCRM.DAL.Common;

namespace JailooCRM.DAL
{
    /// <summary>
    /// Business entity consists of departments. For example, cafe has such departments: bar, kitchen and so on.
    /// </summary>
    public class Department : BaseEntity<int>
    {
        /// <summary>
        /// Poshel na hui
        /// </summary>
        public string Name { get; set; }
        public List<Subcategory> Subcategories { get; set; }
        public List<Product> Products { get; set; }
        public List<Chief> Chief { get; set; }
    }
}
