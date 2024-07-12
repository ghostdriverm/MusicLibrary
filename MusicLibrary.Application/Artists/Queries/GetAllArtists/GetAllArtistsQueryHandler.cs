
using AutoMapper;
using MediatR;
using MusicLibrary.Application.Artists.Dtos;
using MusicLibrary.Domain.Repositories;

namespace MusicLibrary.Application.Artists.Queries.GetAllArtists;

public class GetAllArtistsQueryHandler(IArtistsRepository artistsRepository, IMapper mapper) : IRequestHandler<GetAllArtistsQuery, IEnumerable<ArtistDto>>
{
    public async Task<IEnumerable<ArtistDto>> Handle(GetAllArtistsQuery request, CancellationToken cancellationToken)
    {
        var artists = await artistsRepository.GetAllAsync();
        var results = mapper.Map<IEnumerable<ArtistDto>>(artists);

        return results;
    }
}
