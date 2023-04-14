namespace JailooCRM.DAL
{
    public class PersonBankAccount
    {
        public string BankAccountId { get; set; }
        public virtual BankAccount BankAccount { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
