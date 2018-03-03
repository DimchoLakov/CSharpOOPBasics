using System.Collections.Generic;

public class AddRemoveCollection<T> : IAddRemoveCollection<T>
{
    private List<T> list;
    
    public AddRemoveCollection()
    {
        this.list = new List<T>();
    }

    public int Add(T item)
    {
        list.Insert(0, item);
        return 0;
    }

    public virtual T Remove()
    {
        T toReturn = list[list.Count - 1];
        list.RemoveAt(list.Count - 1);
        return toReturn;
    }
}