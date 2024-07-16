using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Application.Albums.Commands.CreateAlbum;
using MusicLibrary.Application.Albums.Commands.DeleteAlbum;
using MusicLibrary.Application.Albums.Commands.DeleteAlbums;
using MusicLibrary.Application.Albums.Commands.UpdateAlbum;
using MusicLibrary.Application.Albums.Dtos;
using MusicLibrary.Application.Albums.Queries.GetAlbumByIdForArtist;
using MusicLibrary.Application.Albums.Queries.GetAlbumOfTheDay;
using MusicLibrary.Application.Albums.Queries.GetAlbumsForArtist;
namespace MusicLibrary.WebAPI.Controllers;

[ApiController]
[Route("api/artists/{artistId}/[controller]")]
public class AlbumsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAlbum([FromRoute] Guid artistId, CreateAlbumCommand command)
    {
        command.ArtistId = artistId;

        var albumId = await mediator.Send(command);

        return CreatedAtAction(nameof(GetByIdForArtist), new { artistId, albumId }, null);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AlbumDto>>> GetAllForArtist([FromRoute] Guid artistId)
    {
        var albums = await mediator.Send(new GetAlbumsForArtistQuery(artistId));
        return Ok(albums);
    }

    [HttpGet("{albumId}")]
    public async Task<ActionResult<AlbumDto>> GetByIdForArtist([FromRoute] Guid artistId, [FromRoute] Guid albumId)
    {
        var album = await mediator.Send(new GetAlbumByIdForArtistQuery(artistId, albumId));
        return Ok(album);
    }

    [HttpPatch("{albumId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAlbum([FromRoute] Guid albumId, UpdateAlbumCommand command)
    {
        command.AlbumId = albumId;
        await mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{albumId}")]
    public async Task<IActionResult> DeleteAlbum([FromRoute] Guid albumId)
    {
        await mediator.Send(new DeleteAlbumCommand(albumId));
        return NoContent();
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAlbumsForArtist([FromRoute] Guid artistId)
    {
        await mediator.Send(new DeleteAlbumsForArtistCommand(artistId));
        return NoContent();
    }

}
