namespace JailooCRM.DAL
{
    public class Waiter : Person
    {
        public List<Order> Orders { get; set; }
        public decimal ServicePrice { get; set; }
    }
}
