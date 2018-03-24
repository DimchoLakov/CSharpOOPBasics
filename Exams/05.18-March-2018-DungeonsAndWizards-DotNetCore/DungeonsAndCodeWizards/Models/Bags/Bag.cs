using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Bag
{
    protected const int DefaultCapacity = 100;

    protected Bag(int capacity)
    {
        this.Capacity = capacity;
        this.items = new List<Item>();
    }

    private readonly List<Item> items;
    public int Capacity { get; protected set; }

    public int Load => this.items.Sum(c => c.Weight);

    public IReadOnlyCollection<Item> Items => this.items;

    public void AddItem(Item item)
    {
        if (this.Load + item.Weight > this.Capacity)
        {
            throw new InvalidOperationException("Bag is full!");
        }

        this.items.Add(item);
    }

    public Item GetItem(string itemName)
    {
        if (this.items.Count == 0)
        {
            throw new InvalidOperationException("Bag is empty!");
        }

        if (!this.items.Exists(i => i.GetType().Name == itemName))
        {
            throw new ArgumentException($"No item with name {itemName} in bag!");
        }
        
        Item item = this.items.First(i => i.GetType().Name == itemName);
        this.items.Remove(item);
        return item;
    }
}