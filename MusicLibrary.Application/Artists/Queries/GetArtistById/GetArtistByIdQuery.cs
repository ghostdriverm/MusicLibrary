using MediatR;
using MusicLibrary.Application.Artists.Dtos;

namespace MusicLibrary.Application.Artists.Queries.GetArtistById;

public class GetArtistByIdQuery(Guid id) : IRequest<ArtistDto>
{
    public Guid ArtistId { get; } = id;
}
