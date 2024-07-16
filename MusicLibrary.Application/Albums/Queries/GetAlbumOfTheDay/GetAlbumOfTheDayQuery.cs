using MediatR;
using MusicLibrary.Application.Albums.Dtos;
namespace MusicLibrary.Application.Albums.Queries.GetAlbumOfTheDay;

public class GetAlbumOfTheDayQuery : IRequest<AlbumWithArtistDto>
{
}
