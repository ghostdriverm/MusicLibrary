using MediatR;
using MusicLibrary.Domain.Repositories;

namespace MusicLibrary.Application.Songs.Commands.UpdateSongCommand;

public class UpdateSongCommandHandler(ISongsRepository songsRepository) : IRequestHandler<UpdateSongCommand>
{
    public async Task Handle(UpdateSongCommand command, CancellationToken cancellationToken)
    {
        var song = await songsRepository.GetByIdAsync(command.SongId);

        if (song == null)
        {
            throw new Exception("Song not found");
        }

        song.Title = command.Title;
        song.Length = command.Length;

        await songsRepository.SaveChanges();
    }
}
