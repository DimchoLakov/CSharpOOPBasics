public class StartUp
{
    public static void Main()
    {
        RaceTower raceTower = new RaceTower();
        Engine engine = new Engine(raceTower);
        engine.Start();
    }
}