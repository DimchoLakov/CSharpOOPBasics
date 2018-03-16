public class StartUp
{
    public static void Main()
    {
        CarManager carManager = new CarManager();
        Engine engine = new Engine(carManager);
        engine.Start();
    }
}