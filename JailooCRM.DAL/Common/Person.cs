namespace JailooCRM.DAL.Common
{
    public abstract class Person : BaseEntity<int>
    {
        public string Name { get; set; }
        public List<PersonBankAccount> PersonBankAccounts { get; set; }
    }
}
