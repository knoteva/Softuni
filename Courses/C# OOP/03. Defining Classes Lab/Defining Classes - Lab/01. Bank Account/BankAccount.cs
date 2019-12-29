namespace BankAccount
{
    public class BankAccount
    {
        private int id;
        private decimal balance;

        public BankAccount()
        {
            Id = id;
            Balance = balance;
        }

        public int Id { get => id; set => id = value; }
        public decimal Balance { get => balance; set => balance = value; }

        public override string ToString()
        {
            return $"Account {Id}, balance {Balance}";
        }
        public void Deposit(decimal amount)
        {
            Balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            Balance -= amount;
        }

    }
}
