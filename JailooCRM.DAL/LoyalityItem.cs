using JailooCRM.DAL.Common;

namespace JailooCRM.DAL
{
    public class LoyalityItem : BaseEntity<string>
    {
        public decimal SpentMoneyAmount { get; set; }
        public OhuennostLevel OhuennostLevel 
        { 
            get
            {
                if(SpentMoneyAmount > 500)
                {
                    return OhuennostLevel.JSer;
                }
                else if (SpentMoneyAmount > 1000)
                {
                    return OhuennostLevel.Shit;
                }
                else if (SpentMoneyAmount > 1500)
                {
                    return OhuennostLevel.Gey;
                }
                else if (SpentMoneyAmount > 2000)
                {
                    return OhuennostLevel.Norm;
                }
                else if (SpentMoneyAmount > 2500)
                {
                    return OhuennostLevel.Ohuenniy;
                }
                else if (SpentMoneyAmount > 3000)
                {
                    return OhuennostLevel.CSharp;
                }

                return OhuennostLevel.None;
            }
        }

        public int DiscountPercent => 3 * (int)OhuennostLevel;

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }

    public enum OhuennostLevel
    {
        None = 0,
        JSer = 1,
        Shit = 2,
        Gey = 3,
        Norm = 4,
        Ohuenniy = 5,
        CSharp = 6
    }
}
