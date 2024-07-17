using MediatR;
using MusicLibrary.Application.Common;
using MusicLibrary.Application.Songs.Dtos;
using MusicLibrary.Domain.Constants;

namespace MusicLibrary.Application.Songs.Queries.GetAllSongs;

//implemented but not used in the final project
public class GetAllSongsFromSearchQuery : IRequest<PagedResult<SongDto>>
{
    public string? SearchPhrase { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? SortBy { get; set; }
    public SortDirection SortDirection { get; set; }
}
