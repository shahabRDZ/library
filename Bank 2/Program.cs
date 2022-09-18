using System;
using System.Net;
using Bank_2;

namespace MyBank
{
    static class program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount_jadid("shayan", 10000);
            Console.WriteLine($"Amount{account.Numbers}was crated for {account.Owner} ");
            account.MakeWithdrawal(50,DateTime.Today,"SEGA");
            account.MakeWithdrawal(58,DateTime.Today,"MARKET");
            Console.WriteLine(account.Balance);
            Console.WriteLine(account.GetAccountHistory());
        }
    }
    
    
}

