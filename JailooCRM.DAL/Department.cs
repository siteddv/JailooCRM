namespace JailooCRM.DAL
{
    public class Department : BaseEntity<int>
    {
        public string Name { get; set; }
        public List<Subcategory> Subcategories { get; set; }
    }
}
