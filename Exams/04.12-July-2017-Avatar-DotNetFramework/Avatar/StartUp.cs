public class StartUp
{
    public static void Main()
    {
        NationsBuilder nationsBuilder = new NationsBuilder();
        Fight fight = new Fight(nationsBuilder);
        fight.Begin();
    }
}