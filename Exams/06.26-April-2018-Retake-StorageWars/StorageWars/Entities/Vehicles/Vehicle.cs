using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Vehicle
{
    private List<Product> trunk;

    protected Vehicle(int capacity)
    {
        this.trunk = new List<Product>();
        this.Capacity = capacity;
    }

    public int Capacity { get; protected set; }

    public IReadOnlyCollection<Product> Trunk => this.trunk.AsReadOnly();

    public bool IsFull => this.trunk.Sum(p => p.Weight) >= this.Capacity;

    public bool IsEmpty => this.trunk.Count == 0;

    public void LoadProduct(Product product)
    {
        if (this.IsFull)
        {
            throw new InvalidOperationException("Vehicle is full!");
        }

        this.trunk.Add(product);
    }

    public Product Unload()
    {
        if (this.IsEmpty)
        {
            throw new InvalidOperationException("No products left in vehicle!");
        }

        Product lastProduct = this.trunk.Last();

        this.trunk.RemoveAt(this.trunk.Count - 1);

        return lastProduct;
    }
}