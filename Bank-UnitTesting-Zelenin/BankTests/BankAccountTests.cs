using System;
using BankAccountNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTests;

[TestClass]
public class BankAccountTests
{
    [TestMethod]
    public void Debit_WithValidAmount_UpdatesBalance()
    {
        var account = new BankAccount("Arseniy Zelenin", 20.00);

        account.Debit(6.35);

        Assert.AreEqual(13.65, account.Balance, 0.001, "Account not debited correctly");
    }

    [TestMethod]
    public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
    {
        var account = new BankAccount("Arseniy Zelenin", 20.00);

        var exception = Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => account.Debit(-50.00));

        StringAssert.Contains(exception.Message, BankAccount.DebitAmountLessThanZeroMessage);
    }

    [TestMethod]
    public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
    {
        var account = new BankAccount("Arseniy Zelenin", 20.00);

        var exception = Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => account.Debit(30.00));

        StringAssert.Contains(exception.Message, BankAccount.DebitAmountExceedsBalanceMessage);
    }

    [TestMethod]
    public void Credit_WithValidAmount_IncreasesBalance()
    {
        var account = new BankAccount("Arseniy Zelenin", 20.00);

        account.Credit(8.25);

        Assert.AreEqual(28.25, account.Balance, 0.001, "Account not credited correctly");
    }

    [TestMethod]
    public void Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
    {
        var account = new BankAccount("Arseniy Zelenin", 20.00);

        var exception = Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => account.Credit(-1.00));

        StringAssert.Contains(exception.Message, BankAccount.CreditAmountLessThanZeroMessage);
    }

    [TestMethod]
    [DataRow(5.00, true)]
    [DataRow(20.00, true)]
    [DataRow(21.00, false)]
    [DataRow(-1.00, false)]
    public void CanDebit_ReturnsExpectedAvailability(double amount, bool expected)
    {
        var account = new BankAccount("Arseniy Zelenin", 20.00);

        Assert.AreEqual(expected, account.CanDebit(amount));
    }
}
