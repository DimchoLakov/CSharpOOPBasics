using System.Collections.Generic;

public class MyList<T> : IMyList<T>
{
    private List<T> list;

    public MyList()
    {
        this.list = new List<T>();
        this.Used = 0;
    }

    public int Add(T item)
    {
        list.Insert(0, item);
        this.Used++;
        return 0;
    }

    public T Remove()
    {
        T toReturn = list[0];
        list.RemoveAt(0);
        this.Used--;
        return toReturn;
    }

    public int Used { get; private set; }
}