using MediatR;
using MusicLibrary.Application.Artists.Dtos;
using MusicLibrary.Application.Common;
using MusicLibrary.Domain.Constants;

namespace MusicLibrary.Application.Artists.Queries.GetAllArtists;

public class GetAllArtistsFromSearchQuery : IRequest<PagedResult<ArtistDto>>
{
    public string? SearchPhrase { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? SortBy { get; set; }
    public SortDirection SortDirection { get; set; }
}
