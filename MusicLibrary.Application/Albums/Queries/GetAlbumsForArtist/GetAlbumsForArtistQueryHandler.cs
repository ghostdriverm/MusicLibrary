using AutoMapper;
using MediatR;
using MusicLibrary.Application.Albums.Dtos;
using MusicLibrary.Domain.Repositories;

namespace MusicLibrary.Application.Albums.Queries.GetAlbumsForArtist;

public class GetAlbumsForArtistQueryHandler(IArtistsRepository artistsRepository, IAlbumsRepository albumsRepository, IMapper mapper) : IRequestHandler<GetAlbumsForArtistQuery, IEnumerable<AlbumDto>>
{
    public async Task<IEnumerable<AlbumDto>> Handle(GetAlbumsForArtistQuery request, CancellationToken cancellationToken)
    {
        var artist = await artistsRepository.GetByIdAsync(request.ArtistId);

        if (artist == null) throw new Exception("Artist not found");

        var albums = await albumsRepository.GetAllByArtistAsync(request.ArtistId);

        var results = mapper.Map<IEnumerable<AlbumDto>>(albums);

        return results;
    }
}
