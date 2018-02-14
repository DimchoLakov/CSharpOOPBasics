
public class BankAccount
{
    private int id;
    private decimal balance;

    public int Id
    {
        get { return this.id; }
        set { this.id = value; }
    }

    public decimal Balance
    {
        get { return balance; }
        set { this.balance = value; }
    }

    public BankAccount(int id, decimal balance)
    {
        this.id = id;
        this.balance = balance;
    }

    public BankAccount()
    {
    }

    public override string ToString()
    {
        return $"Account {Id}, balance {Balance}";
    }
}