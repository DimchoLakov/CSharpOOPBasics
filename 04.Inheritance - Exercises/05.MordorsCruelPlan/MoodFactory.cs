public static class MoodFactory
{
    public static Mood GetMood(int happinessValue)
    {
        if (happinessValue < -5)
        {
            return new Angry();
        }
        if (happinessValue <= 0)
        {
            return new Sad();
        }
        if (happinessValue <= 15)
        {
            return new Happy();
        }

        return new JavaScript();
    }
}