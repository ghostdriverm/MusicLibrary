using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Application.Artists.Commands.CreateArtist;
using MusicLibrary.Application.Artists.Commands.DeleteArtist;
using MusicLibrary.Application.Artists.Commands.UpdateArtist;
using MusicLibrary.Application.Artists.Dtos;
using MusicLibrary.Application.Artists.Queries.GetAllArtists;
using MusicLibrary.Application.Artists.Queries.GetArtistById;

namespace MusicLibrary.WebAPI.Controllers;

[ApiController]
[Route("api/artists")]
public class ArtistsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreatArtist(CreateArtistCommand command)
    {
        Guid artistId = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { artistId }, null);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ArtistDto>>> GetAll()
    {
        var query = new GetAllArtistsQuery();
        var artists = await mediator.Send(query);
        return Ok(artists);
    }

    [HttpGet("{artistId}")]
    public async Task<ActionResult<ArtistDto>> GetById([FromRoute] Guid artistId)
    {
        var artist = await mediator.Send(new GetArtistByIdQuery(artistId));
        return Ok(artist);
    }

    [HttpPatch("{artistId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateArtist([FromRoute] Guid artistId, UpdateArtistCommand command)
    {
        command.ArtistId = artistId;
        await mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{artistId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteArtist([FromRoute] Guid artistId, DeleteArtistCommand command)
    {
        await mediator.Send(new DeleteArtistCommand(artistId));

        return NoContent();
    }

}
