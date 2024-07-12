using MediatR;

namespace MusicLibrary.Application.Albums.Commands.DeleteAlbum;

public class DeleteAlbumCommand(Guid albumId) : IRequest
{
    public Guid AlbumId { get; } = albumId;
}
