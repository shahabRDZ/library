using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Transactions;

namespace Bank_2;

public class BankAccount_jadid
{
    public string Numbers { get;  }
    public string Owner { get; set; }

    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            foreach (var item in allTransactions)
            {
                balance += item.Amount;

            }

            return balance;
        }
        
    }

    private static int acountNumberseed = 17800;

    private List<Transaction> allTransactions = new List<Transaction>();

    public BankAccount_jadid(string name, decimal initialBalence)
    {
        this.Owner = name;
        MakeDeposit(initialBalence, DateTime.Now, "initial Balanve");
        this.Numbers = acountNumberseed.ToString();
        acountNumberseed++;
    }

    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");

        }

        var deposit = new Transaction(amount, date, note);
        allTransactions.Add(deposit);
    }

    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
        }

        if (Balance - amount < 0)
        {
            throw new InvalidOperationException("Note sufficient founds for this withdrawal");
        }

        var withdrawal = new Transaction(-amount, date, note);
        allTransactions.Add(withdrawal);
        Console.WriteLine($"your credit {Balance}\t{DateTime.Today}");
    }

    public string GetAccountHistory()
    {
        var report = new StringBuilder();
        //header
        report.AppendLine("DATE\t\tAMOUNT\t\tNOTE");
        //rows
        foreach (var item in allTransactions)
        {
            report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{item.Note}");
        }

        return report.ToString();
    }
    
}