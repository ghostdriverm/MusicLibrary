using MediatR;
using MusicLibrary.Application.Albums.Dtos;

namespace MusicLibrary.Application.Albums.Queries.GetAlbumById;

public class GetAlbumByIdQuery(Guid id) : IRequest<AlbumDto>
{
    public Guid AlbumId { get; } = id;
}
