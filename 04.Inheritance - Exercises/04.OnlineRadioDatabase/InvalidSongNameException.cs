public class InvalidSongNameException : InvalidSongException
{
    private const string MESSAGE = "Song name should be between 3 and 30 symbols.";
    public InvalidSongNameException() : base(MESSAGE)
    {
    }
}