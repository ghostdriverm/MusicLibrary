using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Application.Albums.Queries.GetAllAlbums;

namespace MusicLibrary.WebAPI.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AlbumsAllController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAlbums()
    {
        var command = new GetAllAlbumsQuery();
        var albums = await mediator.Send(command);
        return Ok(albums);
    }
}
