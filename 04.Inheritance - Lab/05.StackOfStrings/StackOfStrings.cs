using System.Collections.Generic;

public class StackOfStrings
{
    private List<string> data;

    public List<string> Data
    {
        get { return this.data; }
        set { this.data = value; }
    }

    public StackOfStrings()
    {
        this.Data = new List<string>();
    }

    public void Push(string str)
    {
        this.Data.Add(str);
    }

    public string Pop()
    {
        string str = this.Peek();
        this.Data.Remove(this.Data[Data.Count - 1]);
        return str;
    }

    public string Peek()
    {
        return this.Data[Data.Count - 1];
    }

    public bool IsEmpty()
    {
        return this.Data.Count == 0;
    }
}