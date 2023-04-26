using JailooCRM.DAL.Common;

namespace JailooCRM.DAL
{
    public class BankAccount : BaseEntity<string>
    {
        public decimal TotalAmount { get; set; }
        public List<PersonBankAccount> PersonBankAccounts { get; set; }
    }
}
