using JailooCRM.DAL.Common;

namespace JailooCRM.DAL
{
    public class Client : Person
    {
        public List<Order>? Orders { get; set; }
        public string? LoyalityItemId { get; set; }
        public LoyalityItem LoyalityItem { get; set; }
    }
}
