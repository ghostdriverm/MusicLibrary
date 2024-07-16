using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Application.Albums.Queries.GetAlbumOfTheDay;

namespace MusicLibrary.WebAPI.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AlbumOfTheDayController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAlbumOfTheDay()
    {
        var command = new GetAlbumOfTheDayQuery();
        var albumOfTheDay = await mediator.Send(command);
        return Ok(albumOfTheDay);
    }
}
