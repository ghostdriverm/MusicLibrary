using MediatR;
using MusicLibrary.Application.Albums.Dtos;

namespace MusicLibrary.Application.Albums.Queries.GetAlbumsForArtist;

public class GetAlbumsForArtistQuery(Guid artistId) : IRequest<IEnumerable<AlbumDto>>
{
    public Guid ArtistId { get; } = artistId;
}
