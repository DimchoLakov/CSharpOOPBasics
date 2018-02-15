using System.Collections.Generic;
using System.Linq;

public class Person
{
    private string name;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    private int age;

    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }

    private List<BankAccount> Accounts { get; set; }

    public Person()
    {
    }

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
        Accounts = new List<BankAccount>();
    }

    public Person(string name, int age, List<BankAccount> accounts) : this(name, age)
    {
        this.Accounts = accounts;
    }


    public decimal GetBalance()
    {
        return Accounts.Sum(x => x.Balance);
    }
}