using MediatR;

namespace MusicLibrary.Application.Songs.Commands.DeleteSongsForAlbumCommand;

public class DeleteSongsForAlbumCommand(Guid albumId) : IRequest
{
    public Guid AlbumId { get; } = albumId;
}
