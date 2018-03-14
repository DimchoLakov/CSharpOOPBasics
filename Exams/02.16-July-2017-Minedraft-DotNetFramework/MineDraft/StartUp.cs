public class StartUp
{
    public static void Main()
    {
        DraftManager draftManager = new DraftManager();
        Mine mine = new Mine(draftManager);
        mine.StartMining();
    }
}
