using System;
    class Program
    {
        static void Main()
        {
            var acc = new BankAccount();

            acc.Balance = 15;
            acc.Id = 1;

            Console.WriteLine(acc);
        }
    }
