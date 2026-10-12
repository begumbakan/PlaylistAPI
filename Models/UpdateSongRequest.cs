using System.ComponentModel.DataAnnotations;

namespace PlaylistAPI.Models;

public class UpdateSongRequest
{
    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Artist { get; set; } = string.Empty;
        
    public string Album { get; set; } = string.Empty;
        
    [Range(1, 7200)]
    public int DurationSeconds { get; set; }
        
    public string Genre { get; set; } = string.Empty;
}