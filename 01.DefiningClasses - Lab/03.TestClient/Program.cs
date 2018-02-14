using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<int, BankAccount> bank = new Dictionary<int, BankAccount>();

        string input = Console.ReadLine();

        while (!input.Equals("End"))
        {
            string[] tokens = input
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string command = tokens[0];

            switch (command)
            {
                case "Create":
                    int createId = int.Parse(tokens[1]);
                    TryCreateBankAccount(createId, bank);
                    break;
                case "Deposit":
                    int depositId = int.Parse(tokens[1]);
                    decimal amountToDeposit = decimal.Parse(tokens[2]);
                    TryDepositToBankAccount(depositId, amountToDeposit, bank);
                    break;
                case "Withdraw":
                    int withdrawId = int.Parse(tokens[1]);
                    decimal amountToWithdraw = decimal.Parse(tokens[2]);
                    TryWithdrawFromAccount(withdrawId, amountToWithdraw, bank);
                    break;
                case "Print":
                    int printId = int.Parse(tokens[1]);
                    TryPrintBankAccount(printId, bank);
                    break;
            }

            input = Console.ReadLine();
        }
    }
    
    private static void TryWithdrawFromAccount(int withdrawId, decimal amountToWithdraw, Dictionary<int, BankAccount> bank)
    {
        if (bank.ContainsKey(withdrawId))
        {
            if (bank[withdrawId].Balance >= amountToWithdraw)
            {
                bank[withdrawId].Withdraw(amountToWithdraw);
            }
            else
            {
                Console.WriteLine($"Insufficient balance");
            }
        }
        else
        {
            Console.WriteLine($"Account does not exist");
        }
    }

    private static void TryDepositToBankAccount(int depositId, decimal amountToDeposit, Dictionary<int, BankAccount> bank)
    {
        if (bank.ContainsKey(depositId))
        {
            bank[depositId].Deposit(amountToDeposit);
        }
        else
        {
            Console.WriteLine($"Account does not exist");
        }
    }

    private static void TryPrintBankAccount(int printId, Dictionary<int, BankAccount> bank)
    {
        if (bank.ContainsKey(printId))
        {
            Console.WriteLine(bank[printId]);
        }
        else
        {
            Console.WriteLine($"Account does not exist");
        }
    }

    private static void TryCreateBankAccount(int id, Dictionary<int, BankAccount> bank)
    {
        if (!bank.ContainsKey(id))
        {
            bank.Add(id, new BankAccount(id));
        }
        else
        {
            Console.WriteLine($"Account already exists");
        }
    }
}