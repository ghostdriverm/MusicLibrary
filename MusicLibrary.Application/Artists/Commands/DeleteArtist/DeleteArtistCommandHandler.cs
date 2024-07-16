using MediatR;
using MusicLibrary.Domain.Repositories;

namespace MusicLibrary.Application.Artists.Commands.DeleteArtist;

public class DeleteArtistCommandHandler(IArtistsRepository artistsRepository) : IRequestHandler<DeleteArtistCommand>
{
    public async Task Handle(DeleteArtistCommand command, CancellationToken cancellationToken)
    {
        var artist = await artistsRepository.GetByIdAsync(command.ArtistId);

        if (artist == null)
        {
            throw new Exception("Artist not found!");
        }
        await artistsRepository.Delete(artist);
    }
}
