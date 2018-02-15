public class BankAccount
{
    private int id;

    public int ID
    {
        get { return this.id; }
        set { this.id = value; }
    }

    private decimal balance;

    public decimal Balance
    {
        get { return this.balance; }
        set { this.balance = value; }
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        Balance -= amount;
    }

    public override string ToString()
    {
        return $"Account {this.id}, Balance {this.balance}";
    }
}

