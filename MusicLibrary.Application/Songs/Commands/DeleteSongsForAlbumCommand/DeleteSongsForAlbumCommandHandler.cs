using MediatR;
using MusicLibrary.Domain.Repositories;

namespace MusicLibrary.Application.Songs.Commands.DeleteSongsForAlbumCommand;

public class DeleteSongsForAlbumCommandHandler(IAlbumsRepository albumsRepository, ISongsRepository songsRepository) : IRequestHandler<DeleteSongsForAlbumCommand>
{
    public async Task Handle(DeleteSongsForAlbumCommand command, CancellationToken cancellationToken)
    {
        var album = await albumsRepository.GetByIdAsync(command.AlbumId);

        if (album == null)
        {
            throw new Exception("Album not found.");
        }

        await songsRepository.DeleteAll(album.Songs);
    }
}
