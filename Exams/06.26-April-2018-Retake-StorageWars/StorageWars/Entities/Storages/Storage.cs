using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Storage
{
    private Vehicle[] garage;
    private List<Product> products;

    protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
    {
        this.Name = name;
        this.Capacity = capacity;
        this.GarageSlots = garageSlots;
        this.garage = new Vehicle[this.GarageSlots];
        LoadVehicles(vehicles);
        this.products = new List<Product>();
    }

    private void LoadVehicles(IEnumerable<Vehicle> vehicles)
    {
        int index = 0;
        foreach (var vehicle in vehicles)
        {
            this.garage[index] = vehicle;
            index++;
            if (index == this.garage.Length - 1)
            {
                break;
            }
        }
    }

    public string Name { get; protected set; }

    public int Capacity { get; protected set; }

    public int GarageSlots { get; protected set; }

    public bool IsFull => this.products.Sum(p => p.Weight) >= this.Capacity;

    public IReadOnlyCollection<Vehicle> Garage => Array.AsReadOnly(this.garage);

    public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();

    public Vehicle GetVehicle(int garageSlot)
    {
        if (garageSlot >= this.GarageSlots)
        {
            throw new InvalidOperationException("Invalid garage slot!");
        }

        if (this.garage[garageSlot] == null)
        {
            throw new InvalidOperationException("No vehicle in this garage slot!");
        }

        return this.garage[garageSlot];
    }

    public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
    {
        var vehicle = this.GetVehicle(garageSlot);
        
        int index = -1;

        for (int i = 0; i < deliveryLocation.garage.Length; i++)
        {
            if (deliveryLocation.garage[i] == null)
            {
                index = i;
                break;
            }
        }

        if (index == -1)
        {
            throw new InvalidOperationException("No room in garage!");
        }

        deliveryLocation.garage[index] = vehicle;
        this.garage[garageSlot] = null;

        return index;
    }

    public int UnloadVehicle(int garageSlot)
    {
        if (this.IsFull)
        {
            throw new InvalidOperationException("Storage is full!");
        }

        var vehicle = this.GetVehicle(garageSlot);

        int unloadedProductsCount = 0;

        while (!this.IsFull && !vehicle.IsEmpty)
        {
            this.products.Add(vehicle.Unload());
            unloadedProductsCount++;
        }

        return unloadedProductsCount;
    }

    public override string ToString()
    {
        return $"{this.Name}:{Environment.NewLine}Storage worth: ${this.products.Sum(p => p.Price):f2}";
    }
}