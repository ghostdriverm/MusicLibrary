using MediatR;
using MusicLibrary.Domain.Entities;
using MusicLibrary.Domain.Repositories;

namespace MusicLibrary.Application.Songs.Commands.CreateSongCommand;

internal class CreateSongCommandHandler(IAlbumsRepository albumsRepository, ISongsRepository songsRepository) : IRequestHandler<CreateSongCommand, Guid>
{
    public async Task<Guid> Handle(CreateSongCommand command, CancellationToken cancellationToken)
    {
        var album = await albumsRepository.GetByIdAsync(command.AlbumId);

        if (album == null) throw new Exception("Album not found.");

        var song = new Song
        {
            SongId = Guid.NewGuid(),
            Title = command.Title,
            Length = command.Length,
            AlbumId = command.AlbumId,
        };

        await songsRepository.Create(song);

        return song.SongId;
    }
}
