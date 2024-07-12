using MediatR;

namespace MusicLibrary.Application.Albums.Commands.DeleteAlbums;

public class DeleteAlbumsForArtistCommand(Guid artistId) : IRequest
{
    public Guid ArtistId { get; } = artistId;

}
