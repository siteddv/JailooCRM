namespace JailooCRM.DAL
{
    public class Client : Person
    {
        public List<Order> Orders { get; set; }
    }
}
