using JailooCRM.DAL.Common;

namespace JailooCRM.DAL
{
    public class Order : BaseEntity<int>
    {
        public int? ClientId { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public DateTime DateClosed { get; set; }
        public int? ClientPlaceId { get; set; }
        public ClientPlace ClientPlace { get; set; }
        public int? WaiterId { get; set; }
        public Waiter Waiter { get; set; }
    }
}
