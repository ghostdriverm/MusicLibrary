
using MediatR;
using MusicLibrary.Application.Albums.Dtos;

namespace MusicLibrary.Application.Albums.Queries.GetAllAlbums;

public class GetAllAlbumsQuery : IRequest<IEnumerable<AlbumWithArtistDto>>
{
}
