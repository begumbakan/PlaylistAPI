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
    public ActionResult<List<Song>> GetAllSongs()
    {
        return Ok(_service.GetAllSongs());
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
}