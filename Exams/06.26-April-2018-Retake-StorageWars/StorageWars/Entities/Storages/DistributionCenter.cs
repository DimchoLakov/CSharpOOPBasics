using System.Collections.Generic;

public class DistributionCenter : Storage
{
    private const int DistributionCenterCapacity = 2;
    private const int DistributionCenterGarageSlots = 5;

    public DistributionCenter(string name) : base(name, DistributionCenterCapacity, DistributionCenterGarageSlots, new List<Vehicle>() { new Van(), new Van(), new Van() })
    {
    }
}