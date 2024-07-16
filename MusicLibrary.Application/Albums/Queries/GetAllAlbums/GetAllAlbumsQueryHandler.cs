
using MediatR;
using MusicLibrary.Application.Albums.Dtos;
using MusicLibrary.Domain.Entities;
using MusicLibrary.Domain.Repositories;

namespace MusicLibrary.Application.Albums.Queries.GetAllAlbums;

public class GetAllAlbumsQueryHandler(IAlbumsRepository albumsRepository, IArtistsRepository artistsRepository) : IRequestHandler<GetAllAlbumsQuery, IEnumerable<AlbumWithArtistDto>>
{
    public async Task<IEnumerable<AlbumWithArtistDto>> Handle(GetAllAlbumsQuery request, CancellationToken cancellationToken)
    {
        var albums = await albumsRepository.GetAllAsync();
        var artists = await artistsRepository.GetAllAsync();

        var artistDictionary = artists.ToDictionary(artist => artist.ArtistId, artist => artist.Name);

        var albumWithArtistDtos = albums.Select(album => new AlbumWithArtistDto
        {
            AlbumId = album.AlbumId,
            Title = album.Title,
            Description = album.Description,
            ArtistId = album.ArtistId,
            ArtistName = artistDictionary.ContainsKey(album.ArtistId) ? artistDictionary[album.ArtistId] : "Unknown Artist"
        }).ToList();

        return albumWithArtistDtos;
    }
}
