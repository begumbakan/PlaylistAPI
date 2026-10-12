using PlaylistAPI.Models;
namespace PlaylistAPI.Services;

public class PlaylistService
{
    private readonly List<Song> _songs = new();
    private int _nextId;

    public PlaylistService()
    {
        _songs.Add(new Song
        {
            Id = 1,
            Title = "Blinding Lights",
            Artist = "The Weeknd",
            Album = "After Hours",
            DurationSeconds = 212,
            Genre = "Pop",
            IsFavorite = true,
            Position = 1
        });

        _songs.Add(new Song
        {
            Id = 2,
            Title = "Levitating",
            Artist = "Dua Lipa",
            Album = "Future Nostalgia",
            DurationSeconds = 220,
            Genre = "Pop",
            IsFavorite = false,
            Position = 2
        });

        _songs.Add(new Song
        {
            Id = 3,
            Title = "Watermelon Sugar",
            Artist = "Harry Styles",
            Album = "Fine Line",
            DurationSeconds = 214,
            Genre = "Pop",
            IsFavorite = true,
            Position = 3
        });

        _songs.Add(new Song
        {
            Id = 4,
            Title = "Save Your Tears",
            Artist = "The Weeknd",
            Album = "After Hours",
            DurationSeconds = 246,
            Genre = "R&B",
            IsFavorite = false,
            Position = 4
        });

        _songs.Add(new Song
        {
            Id = 5,
            Title = "Peaches",
            Artist = "Justin Bieber",
            Album = "Justice",
            DurationSeconds = 154,
            Genre = "Pop",
            IsFavorite = true,
            Position = 5
        });

        _nextId = 6;
    }

    public List<Song> GetAllSongs() => _songs;

    public Song? GetSongById(int id) => _songs.FirstOrDefault(s => s.Id == id);

    public Song AddSong(CreateSongRequest request)
    {
        Song song = new Song
        {
            Id = _nextId++,
            Title = request.Title,
            Artist = request.Artist,
            Album = request.Album,
            DurationSeconds = request.DurationSeconds,
            Genre = request.Genre,
            IsFavorite = false,
            Position = _songs.Count + 1
        };

        _songs.Add(song);
        return song;
    }
}