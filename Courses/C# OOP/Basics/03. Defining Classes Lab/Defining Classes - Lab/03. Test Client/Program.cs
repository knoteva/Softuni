namespace TestClient
{
    using System;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main()
        {
            Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split();

                int accountId = int.Parse(command[1]);

                switch (command[0])
                {
                    case "Create":
                        {
                            if (!accounts.ContainsKey(accountId))
                            {
                                accounts.Add(accountId, new BankAccount() { Id = accountId });
                            }
                            else
                            {
                                Console.WriteLine($"Account already exists");
                            }
                        }
                        break;
                    case "Deposit":
                        {
                            if (!accounts.ContainsKey(accountId))
                            {
                                Console.WriteLine($"Account does not exist");
                            }
                            else
                            {
                                decimal amount = decimal.Parse(command[2]);
                                accounts[accountId].Deposit(amount);
                            }
                        }
                        break;
                    case "Withdraw":
                        {
                            if (!accounts.ContainsKey(accountId))
                            {
                                Console.WriteLine($"Account does not exist");
                            }
                            else
                            {
                                decimal amount = decimal.Parse(command[2]);
                                accounts[accountId].Withdraw(amount);
                            }
                        }
                        break;
                    case "Print":
                        {

                            if (!accounts.ContainsKey(accountId))
                            {
                                Console.WriteLine($"Account does not exist");
                            }
                            else
                            {
                                Console.WriteLine(accounts[accountId]);
                            }
                        }
                        break;
                }
            }
        }
    }
}