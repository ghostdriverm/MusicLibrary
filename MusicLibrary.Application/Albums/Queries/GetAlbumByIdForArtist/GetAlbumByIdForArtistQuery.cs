using MediatR;
using MusicLibrary.Application.Albums.Dtos;

namespace MusicLibrary.Application.Albums.Queries.GetAlbumByIdForArtist;

public class GetAlbumByIdForArtistQuery(Guid artistId, Guid albumId) : IRequest<AlbumDto>
{
    public Guid ArtistId { get; } = artistId;
    public Guid AlbumId { get; } = albumId;
}
