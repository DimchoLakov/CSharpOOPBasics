public class Gpu : Product
{
    private const double GpuWeight = 0.7d;

    public Gpu(double price) : base(price, GpuWeight)
    {
    }
}