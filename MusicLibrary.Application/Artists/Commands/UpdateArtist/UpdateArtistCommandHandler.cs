using MediatR;
using MusicLibrary.Domain.Repositories;

namespace MusicLibrary.Application.Artists.Commands.UpdateArtist;

public class UpdateArtistCommandHandler(IArtistsRepository artistsRepository) : IRequestHandler<UpdateArtistCommand>
{
    public async Task Handle(UpdateArtistCommand request, CancellationToken cancellationToken)
    {
        var artist = await artistsRepository.GetByIdAsync(request.ArtistId);

        if (artist == null) throw new Exception("Artist not found!");
        
        artist.Name = request.Name;
        
        await artistsRepository.SaveChanges();
    }
}
