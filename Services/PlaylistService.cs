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

    public List<Song> GetSongs(string? search, string? genre, string? sortBy, string? order)
    {
        IEnumerable<Song> result = _songs;

        if (!string.IsNullOrWhiteSpace(search))
        {
            result = result.Where(s =>
                s.Title.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                s.Artist.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                s.Album.Contains(search, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(genre))
        {
            result = result.Where(s => s.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase));
        }

        bool desc = string.Equals(order, "desc", StringComparison.OrdinalIgnoreCase);

        result = sortBy?.ToLower() switch
        {
            "title" => desc ? result.OrderByDescending(s => s.Title) : result.OrderBy(s => s.Title),
            "artist" => desc ? result.OrderByDescending(s => s.Artist) : result.OrderBy(s => s.Artist),
            "duration" => desc ? result.OrderByDescending(s => s.DurationSeconds) : result.OrderBy(s => s.DurationSeconds),
            _ => result.OrderBy(s => s.Position)
        };

        return result.ToList();
    }

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

    public bool DeleteSong(int id)
    {
        var song = GetSongById(id);
        if (song == null)
        {
            return false;
        }

        _songs.Remove(song);

        for (int i = 0; i < _songs.Count; i++)
        {
            _songs[i].Position = i + 1;
        }

        return true;
    }

    public Song? UpdateSong(int id, UpdateSongRequest request)
    {
        var song = GetSongById(id);
        if (song == null)
        {
            return null;
        }

        song.Title = request.Title;
        song.Artist = request.Artist;
        song.Album = request.Album;
        song.DurationSeconds = request.DurationSeconds;
        song.Genre = request.Genre;

        return song;
    }

    public Song? SetFavorite(int id, bool isFavorite)
    {
        var song = GetSongById(id);
        if (song == null)
        {
            return null;
        }

        song.IsFavorite = isFavorite;
        return song;
    }
}