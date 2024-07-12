using AutoMapper;
using MediatR;
using MusicLibrary.Application.Artists.Dtos;
using MusicLibrary.Application.Common;
using MusicLibrary.Domain.Repositories;

namespace MusicLibrary.Application.Artists.Queries.GetAllArtists;

public class GetAllArtistsFromSearchQueryHandler(IMapper mapper, IArtistsRepository artistsRepository) : IRequestHandler<GetAllArtistsFromSearchQuery, PagedResult<ArtistDto>>
{
    public async Task<PagedResult<ArtistDto>> Handle(GetAllArtistsFromSearchQuery request, CancellationToken cancellationToken)
    {
        var (artists, totalCount) = await artistsRepository.GetAllMatchingAsync(request.SearchPhrase,
            request.PageSize,
            request.PageNumber,
            request.SortBy,
            request.SortDirection);

        var artistsDtos = mapper.Map<IEnumerable<ArtistDto>>(artists);

        var result = new PagedResult<ArtistDto>(artistsDtos, totalCount, request.PageSize, request.PageNumber);
        return result;
    }
}
