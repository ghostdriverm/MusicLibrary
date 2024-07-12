using MediatR;
using MusicLibrary.Domain.Repositories;

namespace MusicLibrary.Application.Albums.Commands.DeleteAlbum;

public class DeleteAlbumCommandHandler(IAlbumsRepository albumsRepository) : IRequestHandler<DeleteAlbumCommand>
{
    public async Task Handle(DeleteAlbumCommand command, CancellationToken cancellationToken) 
    {
        var album = await albumsRepository.GetByIdAsync(command.AlbumId);

        if (album == null)
        {
            throw new Exception("Album not found");
        }

        await albumsRepository.Delete(album);
    }
}
