namespace JailooCRM.DAL
{
    public class Chief : Person
    {
        public Specialization Specialization { get; set; }
        public bool IsHead { get; set; }
        public int DeprtmentId { get; set; }
        public Department Department { get; set; }
    }
}
