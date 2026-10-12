namespace PlaylistAPI.Models;

public class PlaylistSummary
{
    public int SongCount { get; set; }
    public int TotalDurationSeconds { get; set; }
    public string TotalDuration { get; set; } = string.Empty;
}