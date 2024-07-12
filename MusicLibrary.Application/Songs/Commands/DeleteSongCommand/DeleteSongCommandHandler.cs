using MediatR;
using MusicLibrary.Domain.Repositories;

namespace MusicLibrary.Application.Songs.Commands.DeleteSongCommand;

public class DeleteSongCommandHandler(ISongsRepository songsRepository) : IRequestHandler<DeleteSongCommand>
{
    public async Task Handle(DeleteSongCommand command, CancellationToken cancellationToken)
    {
        var song = await songsRepository.GetByIdAsync(command.SongId);

        if (song == null) throw new Exception("Song not found");

        await songsRepository.Delete(song);
    }
}
