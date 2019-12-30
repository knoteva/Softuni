namespace BankAccount
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            BankAccount a = new BankAccount();
            a.Id = 1;
            a.Deposit(200);
            a.Withdraw(100);
            Console.WriteLine(a);
        }
    }
}
