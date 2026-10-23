using System;

namespace BankAccountNS;

/// <summary>
/// Учебный класс банковского счета. Выполнил Зеленин Арсений.
/// </summary>
public class BankAccount
{
    public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
    public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";
    public const string CreditAmountLessThanZeroMessage = "Credit amount is less than zero";

    private readonly string customerName;
    private double balance;

    private BankAccount()
    {
        customerName = string.Empty;
    }

    public BankAccount(string customerName, double balance)
    {
        this.customerName = customerName;
        this.balance = balance;
    }

    public string CustomerName => customerName;

    public double Balance => balance;

    public bool CanDebit(double amount) => amount >= 0 && amount <= balance;

    public void Debit(double amount)
    {
        if (amount > balance)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), amount, DebitAmountExceedsBalanceMessage);
        }

        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), amount, DebitAmountLessThanZeroMessage);
        }

        balance -= amount;
    }

    public void Credit(double amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), amount, CreditAmountLessThanZeroMessage);
        }

        balance += amount;
    }

    public static void Main()
    {
        var account = new BankAccount("Arseniy Zelenin", 15.50);
        account.Credit(4.50);
        account.Debit(7.25);
        Console.WriteLine("Current balance is ${0:F2}", account.Balance);
    }
}
