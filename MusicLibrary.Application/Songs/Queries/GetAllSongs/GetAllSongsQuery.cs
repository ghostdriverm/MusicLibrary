using MediatR;
using MusicLibrary.Application.Songs.Dtos;

namespace MusicLibrary.Application.Songs.Queries.GetAllSongs;

public class GetAllSongsQuery : IRequest<IEnumerable<SongDto>>
{
}
