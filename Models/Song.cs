namespace PlaylistAPI.Models;

public class Song
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Artist { get; set; } = string.Empty;
    public string Album { get; set; } = string.Empty;
    public int DurationSeconds { get; set; }
    public string Genre { get; set; } = string.Empty;
    public bool IsFavorite { get; set; }
    public int Position { get; set; }
}