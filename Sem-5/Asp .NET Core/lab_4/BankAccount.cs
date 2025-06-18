using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4
{
    internal class BankAccount
    {
        private double balance;
        private string name;
        public BankAccount(String name, double balance) { 
            this.name = name;
            this.balance = balance;
        }
        public void Deposit(double amount)
        {
            balance += amount;
            Console.WriteLine($"{amount} deposited. New balance: {balance}");
        }
        public void Deposit(string checkNumber, double amount)
        {
            balance += amount;
            Console.WriteLine($"Check {checkNumber} deposited. Amount: {amount}. New balance: {balance}");
        }
        public void Withdraw(double amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"{amount} withdrawn. New balance: {balance}");
            }
            else
            {
                Console.WriteLine("Insufficient funds for withdrawal.");
            }
        }
        public void Withdraw(string checkNumber, double amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Check {checkNumber} withdrawn. Amount: {amount}. New balance: {balance}");
            }
            else
            {
                Console.WriteLine("Insufficient funds for withdrawal.");
            }
        }
    }
}
