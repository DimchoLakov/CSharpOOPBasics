public class InvalidSongMinutesException : InvalidSongLengthException
{
    private const string MESSAGE = "Song minutes should be between 0 and 14.";
    public InvalidSongMinutesException() : base(MESSAGE)
    {
    }
}