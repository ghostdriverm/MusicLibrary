using MediatR;
using MusicLibrary.Application.Songs.Dtos;

namespace MusicLibrary.Application.Songs.Queries.GetSongsForArtist;

public class GetSongsForArtistQuery(Guid artistId) : IRequest<IEnumerable<SongDto>>
{
    public Guid ArtistId { get; } = artistId;
}
