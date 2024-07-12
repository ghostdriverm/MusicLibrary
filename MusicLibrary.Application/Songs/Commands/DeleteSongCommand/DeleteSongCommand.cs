using MediatR;

namespace MusicLibrary.Application.Songs.Commands.DeleteSongCommand;

public class DeleteSongCommand(Guid songId) : IRequest
{
    public Guid SongId { get; } = songId;
}
