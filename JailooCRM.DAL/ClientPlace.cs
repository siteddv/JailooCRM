using JailooCRM.DAL.Common;

namespace JailooCRM.DAL
{
    public class ClientPlace : BaseEntity<int>
    {
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
    }
}
