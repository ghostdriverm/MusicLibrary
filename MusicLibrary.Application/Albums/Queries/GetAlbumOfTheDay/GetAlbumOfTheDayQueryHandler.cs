
using MediatR;
using MusicLibrary.Application.Albums.Dtos;
using MusicLibrary.Domain.Entities;
using MusicLibrary.Domain.Repositories;

namespace MusicLibrary.Application.Albums.Queries.GetAlbumOfTheDay;

public class GetAlbumOfTheDayQueryHandler(IAlbumsRepository albumsRepository, IArtistsRepository artistsRepository) : IRequestHandler<GetAlbumOfTheDayQuery, AlbumWithArtistDto>
{
    public async Task<AlbumWithArtistDto> Handle(GetAlbumOfTheDayQuery request, CancellationToken cancellationToken)
    {
        var albumOfTheDay = await albumsRepository.GetAlbumOfTheDay();
        if (albumOfTheDay == null)
        {
            throw new Exception("No album found for the day.");
        }

        var artist = await artistsRepository.GetByIdAsync(albumOfTheDay.ArtistId);

        if (artist == null)
        {
            throw new Exception("Artist not found.");
        }

        return new AlbumWithArtistDto
        {
            AlbumId = albumOfTheDay.AlbumId,
            Title = albumOfTheDay.Title,
            Description = albumOfTheDay.Description,
            ArtistId = albumOfTheDay.ArtistId,
            ArtistName = artist.Name
        };
    }
}
