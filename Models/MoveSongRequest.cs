using System.ComponentModel.DataAnnotations;

namespace PlaylistAPI.Models;

public class MoveSongRequest
{
    [Range(1, int.MaxValue)]
    public int Position { get; set; }
}