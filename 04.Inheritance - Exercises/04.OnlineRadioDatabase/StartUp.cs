using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<Song> playlist = new List<Song>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            try
            {
                Song song = ReadSong(Console.ReadLine());
                playlist.Add(song);
                Console.WriteLine("Song added.");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        PrintPlaylistInfo(playlist);
    }

    private static void PrintPlaylistInfo(List<Song> playlist)
    {
        int totalSeconds = playlist.Sum(p => p.Seconds + p.Minutes * 60);
        int hours = totalSeconds / 3600;
        int minutes = totalSeconds / 60 % 60;
        int seconds = totalSeconds % 60;

        Console.WriteLine($"Songs added: {playlist.Count}");
        Console.WriteLine($"Playlist length: {hours}h {minutes}m {seconds}s");
    }

    private static Song ReadSong(string readLine)
    {
        string[] tokens = readLine.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length < 3)
        {
            throw new InvalidSongException();
        }
        string artistName = tokens[0];
        string songName = tokens[1];
        string[] timeTokens = tokens[2].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

        int min;
        int sec;
        if (timeTokens.Length < 2 || !int.TryParse(timeTokens[0], out min) || !int.TryParse(timeTokens[1], out sec))
        {
            throw new InvalidSongLengthException();
        }
        int minutes = int.Parse(timeTokens[0]);
        int seconds = int.Parse(timeTokens[1]);

        return new Song(artistName, songName, minutes, seconds);
    }
}