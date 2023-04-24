namespace JailooCRM.DAL
{
    public class Department : BaseEntity<int>
    {
        public string Name { get; set; }
        public List<Subcategory> Subcategories { get; set; }
        public List<Product> Products { get; set; }
        public List<Chief> Chief { get; set; }
    }
}
