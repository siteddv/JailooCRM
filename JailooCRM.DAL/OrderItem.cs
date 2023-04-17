namespace JailooCRM.DAL
{
    public class OrderItem : BaseEntity<int>
    {
        public int ProductQuantity { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
