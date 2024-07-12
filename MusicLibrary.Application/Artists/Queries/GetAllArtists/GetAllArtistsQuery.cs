using MediatR;
using MusicLibrary.Application.Artists.Dtos;

namespace MusicLibrary.Application.Artists.Queries.GetAllArtists;

public class GetAllArtistsQuery : IRequest<IEnumerable<ArtistDto>>
{
}
