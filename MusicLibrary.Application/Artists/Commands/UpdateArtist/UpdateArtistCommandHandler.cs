using MediatR;
using MusicLibrary.Domain.Repositories;

namespace MusicLibrary.Application.Artists.Commands.UpdateArtist;

public class UpdateArtistCommandHandler(IArtistsRepository artistsRepository, IAlbumsRepository albumsRepository) : IRequestHandler<UpdateArtistCommand>
{
    public async Task Handle(UpdateArtistCommand request, CancellationToken cancellationToken)
    {
        var artist = await artistsRepository.GetByIdAsync(request.ArtistId);

        if (artist == null)
        {
            throw new Exception("Artist not found!");
        }

        var exisitingArtist = await artistsRepository.GetByNameAsync(request.Name);

        if (exisitingArtist != null && exisitingArtist.ArtistId != artist.ArtistId)
        {
            // Update albums to associate them with the existing artist
            foreach (var album in artist.Albums)
            {
                album.ArtistId = exisitingArtist.ArtistId;
            }


        }
        else
        {
            //Update artist name if the new name is unique or the same artist
            artist.Name = request.Name;

        }


        await artistsRepository.UpdateAsync(artist);
    }
}
