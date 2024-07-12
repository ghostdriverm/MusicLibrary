using MediatR;
using MusicLibrary.Application.Songs.Dtos;

namespace MusicLibrary.Application.Songs.Queries.GetSongsForAlbum;

public class GetSongsForAlbumQuery(Guid albumId) : IRequest<IEnumerable<SongDto>>
{
    public Guid AlbumId { get; } = albumId;
}
