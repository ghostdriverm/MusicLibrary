using MediatR;
using MusicLibrary.Domain.Repositories;

namespace MusicLibrary.Application.Albums.Commands.DeleteAlbums;

public class DeleteAlbumsForArtistCommandHandler(IArtistsRepository artistsRepository, IAlbumsRepository albumsRepository) : IRequestHandler<DeleteAlbumsForArtistCommand>
{
    public async Task Handle(DeleteAlbumsForArtistCommand command, CancellationToken cancellationToken)
    {
        var artist = await artistsRepository.GetByIdAsync(command.ArtistId);

        if (artist == null) throw new Exception("Artist not found.");

        await albumsRepository.DeleteAll(artist.Albums);
    }
}
