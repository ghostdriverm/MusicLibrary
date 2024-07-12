using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Application.Songs.Commands.CreateSongCommand;
using MusicLibrary.Application.Songs.Commands.DeleteSongCommand;
using MusicLibrary.Application.Songs.Commands.DeleteSongsForAlbumCommand;
using MusicLibrary.Application.Songs.Commands.UpdateSongCommand;
using MusicLibrary.Application.Songs.Dtos;
using MusicLibrary.Application.Songs.Queries.GetAllSongs;
using MusicLibrary.Application.Songs.Queries.GetSongsForAlbum;
using MusicLibrary.Application.Songs.Queries.GetSongsForArtist;

namespace MusicLibrary.WebAPI.Controllers;

[ApiController]
[Route("api/artists/{artistId}/[controller]")]
[Route("api/artists/{artistId}/albums/{albumId}/[controller]")]
public class SongsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [Route("/api/artists/{artistId}/albums/{albumId}/songs")]
    public async Task<IActionResult> CreateSong([FromRoute] Guid artistId, [FromRoute] Guid albumId, CreateSongCommand command)
    {
        command.AlbumId = albumId;

        var songId = await mediator.Send(command);

        return CreatedAtAction(nameof(GetSongsByAlbum), new { artistId, albumId }, null);
    }

    [HttpGet]
    [Route("/api/songs")]
    public async Task<ActionResult<IEnumerable<SongDto>>> GetAll()
    {
        var query = new GetAllSongsQuery();
        var songs = await mediator.Send(query);
        return Ok(songs);
    }

    [HttpGet]
    [Route("/api/artists/{artistId}/songs")]
    public async Task<ActionResult<IEnumerable<SongDto>>> GetSongsByArtistId([FromRoute] Guid artistId)
    {
        var songs = await mediator.Send(new GetSongsForArtistQuery(artistId));
        return Ok(songs);
    }

    [HttpGet]
    [Route("/api/artists/{artistId}/albums/{albumId}/songs")]
    public async Task<ActionResult<IEnumerable<SongDto>>> GetSongsByAlbum([FromRoute] Guid albumId)
    {
        var songs = await mediator.Send(new GetSongsForAlbumQuery(albumId));
        return Ok(songs);
    }

    [HttpPatch]
    [Route("/api/artists/{artistId}/albums/{albumId}/songs/{songId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateSong([FromRoute] Guid songId, UpdateSongCommand command)
    {
        command.SongId = songId;
        await mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("/api/artists/{artistId}/albums/{albumId}/songs/delete")]
    public async Task<IActionResult> DeleteSongsForAlbum([FromRoute] Guid albumId)
    {
        await mediator.Send(new DeleteSongsForAlbumCommand(albumId));
        return NoContent();
    }

    [HttpDelete("/api/artists/{artistId}/albums/{albumId}/songs/{songId}")]
    public async Task<IActionResult> DeleteSong([FromRoute] Guid songId)
    {
        await mediator.Send(new DeleteSongCommand(songId));
        return NoContent();
    }

}
