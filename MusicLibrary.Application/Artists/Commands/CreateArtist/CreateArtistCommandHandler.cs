using AutoMapper;
using MediatR;
using MusicLibrary.Domain.Entities;
using MusicLibrary.Domain.Repositories;

namespace MusicLibrary.Application.Artists.Commands.CreateArtist;

public class CreateArtistCommandHandler(IArtistsRepository artistsRepository, IMapper mapper) : IRequestHandler<CreateArtistCommand, Guid>
{
    public async Task<Guid> Handle(CreateArtistCommand request, CancellationToken cancellationToken)
    {

        var artist = mapper.Map<Artist>(request);
        artist.ArtistId = Guid.NewGuid();


        await artistsRepository.Create(artist);
        return artist.ArtistId;
    }
}
