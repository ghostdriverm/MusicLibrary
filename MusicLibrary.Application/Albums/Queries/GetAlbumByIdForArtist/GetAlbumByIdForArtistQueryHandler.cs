using AutoMapper;
using MediatR;
using MusicLibrary.Application.Albums.Dtos;
using MusicLibrary.Domain.Repositories;

namespace MusicLibrary.Application.Albums.Queries.GetAlbumByIdForArtist;

public class GetAlbumByIdForArtistQueryHandler(IArtistsRepository artistsRepository, IAlbumsRepository albumsRepository, IMapper mapper) : IRequestHandler<GetAlbumByIdForArtistQuery, AlbumDto>
{
    public async Task<AlbumDto> Handle(GetAlbumByIdForArtistQuery request, CancellationToken cancellationToken)
    {
        var artist = await artistsRepository.GetByIdAsync(request.ArtistId);

        if (artist == null)
        {
            throw new Exception("Artist not found");
        }
        var albums = await albumsRepository.GetByIdAsync(request.AlbumId);

        var results = mapper.Map<AlbumDto>(albums);

        return results;
    }
}
