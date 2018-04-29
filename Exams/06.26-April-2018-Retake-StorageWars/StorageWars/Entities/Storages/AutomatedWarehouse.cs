using System.Collections.Generic;

public class AutomatedWarehouse : Storage
{
    private const int AutomatedWarehouseCapacity = 1;
    private const int AutomatedWarehouseGarageSlots = 2;
    //private readonly List<Vehicle> Vehicles = new List<Vehicle>() { new Truck() };

    public AutomatedWarehouse(string name) : base(name, AutomatedWarehouseCapacity, AutomatedWarehouseGarageSlots, new List<Vehicle>() { new Truck() })
    {
    }
}