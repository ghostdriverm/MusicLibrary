using AutoMapper;
using MediatR;
using MusicLibrary.Application.Albums.Dtos;
using MusicLibrary.Domain.Repositories;

namespace MusicLibrary.Application.Albums.Queries.GetAlbumByIdForArtist;

public class GetAlbumByIdForArtistQueryHandler(IArtistsRepository artistsRepository, IMapper mapper) : IRequestHandler<GetAlbumByIdForArtistQuery, AlbumDto>
{
    public async Task<AlbumDto> Handle(GetAlbumByIdForArtistQuery request, CancellationToken cancellationToken)
    {
        var artist = await artistsRepository.GetByIdAsync(request.ArtistId);

        if (artist == null) throw new Exception("Artist not found.");

        var album = artist.Albums.FirstOrDefault(a => a.AlbumId == request.AlbumId);
        if (album == null) throw new Exception("Album not found.");

        var result = mapper.Map<AlbumDto>(album);
        return result;
    }
}
