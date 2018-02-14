using System;

class Program
{
    static void Main()
    {
        BankAccount bankAcc = new BankAccount();

        bankAcc.ID = 1;
        bankAcc.Deposit(125);
        bankAcc.Withdraw(110);

        Console.WriteLine(bankAcc);
    }
}
