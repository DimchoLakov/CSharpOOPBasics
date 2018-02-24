public class InvalidSongLengthException : InvalidSongException
{
    private const string MESSAGE = "Invalid song length.";
    public InvalidSongLengthException() : base(MESSAGE)
    {
    }

    public InvalidSongLengthException(string message) : base(message)
    {
    }
}