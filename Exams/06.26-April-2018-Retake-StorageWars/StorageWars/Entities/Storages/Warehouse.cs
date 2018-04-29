using System.Collections.Generic;

public class Warehouse : Storage
{
    private const int WarehouseCapacity = 10;
    private const int WarehouseGarageSlots = 10;

    public Warehouse(string name) : base(name, WarehouseCapacity, WarehouseGarageSlots, new List<Vehicle>() { new Semi(), new Semi(), new Semi() })
    {
    }
}