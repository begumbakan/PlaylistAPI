using Microsoft.AspNetCore.Mvc;
using PlaylistAPI.Models;
using PlaylistAPI.Services;
namespace PlaylistAPI.Controllers;

[ApiController]
[Route("api/v1/songs")]
public class SongsController : ControllerBase
{
    private readonly PlaylistService _service;

    public SongsController(PlaylistService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<Song>> GetSongs(
        [FromQuery] string? search,
        [FromQuery] string? genre,
        [FromQuery] string? sortBy,
        [FromQuery] string? order)
    {
        return Ok(_service.GetSongs(search, genre, sortBy, order));
    }

    [HttpGet("{id}")]
    public ActionResult<Song> GetSongById(int id)
    {
        var song = _service.GetSongById(id);
        if (song == null)
        {
            return NotFound();
        }
        return Ok(song);
    }

    [HttpPost]
    public ActionResult<Song> AddSong([FromBody] CreateSongRequest request)
    {
        var song = _service.AddSong(request);
        return CreatedAtAction(nameof(GetSongById), new { id = song.Id }, song);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteSong(int id)
    {
        if (!_service.DeleteSong(id))
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpPut("{id}")]
    public ActionResult<Song> UpdateSong(int id, [FromBody] UpdateSongRequest request)
    {
        var song = _service.UpdateSong(id, request);
        if (song == null)
        {
            return NotFound();
        }
        return Ok(song);
    }

    [HttpPut("{id}/favorite")]
    public ActionResult<Song> AddFavorite(int id)
    {
        var song = _service.SetFavorite(id, true);
        if (song == null)
        {
            return NotFound();
        }
        return Ok(song);
    }

    [HttpDelete("{id}/favorite")]
    public ActionResult<Song> RemoveFavorite(int id)
    {
        var song = _service.SetFavorite(id, false);
        if (song == null)
        {
            return NotFound();
        }
        return Ok(song);
    }
}