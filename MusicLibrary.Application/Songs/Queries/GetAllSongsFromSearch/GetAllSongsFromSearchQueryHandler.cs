using AutoMapper;
using MediatR;
using MusicLibrary.Application.Common;
using MusicLibrary.Application.Songs.Dtos;
using MusicLibrary.Domain.Repositories;

namespace MusicLibrary.Application.Songs.Queries.GetAllSongs;

public class GetAllSongsFromSearchQueryHandler(IMapper mapper, ISongsRepository songsRepository) : IRequestHandler<GetAllSongsFromSearchQuery, PagedResult<SongDto>>
{
    public async Task<PagedResult<SongDto>> Handle(GetAllSongsFromSearchQuery request, CancellationToken cancellationToken)
    {
        var (songs, totalCount) = await songsRepository.GetAllMatchingAsync(request.SearchPhrase,
            request.PageSize,
            request.PageNumber,
            request.SortBy,
            request.SortDirection);

        var songsDtos = mapper.Map<IEnumerable<SongDto>>(songs);

        var result = new PagedResult<SongDto>(songsDtos, totalCount, request.PageSize, request.PageNumber);
        return result;
    }
}
