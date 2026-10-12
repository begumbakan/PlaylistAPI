using Microsoft.AspNetCore.Mvc;
using PlaylistAPI.Models;
using PlaylistAPI.Services;
namespace PlaylistAPI.Controllers;

[ApiController]
[Route("api/v1/playlist")]
public class PlaylistController : ControllerBase
{
    private readonly PlaylistService _service;

    public PlaylistController(PlaylistService service)
    {
        _service = service;
    }

    [HttpGet("summary")]
    public ActionResult<PlaylistSummary> GetSummary()
    {
        return Ok(_service.GetSummary());
    }
}