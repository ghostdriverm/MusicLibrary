using AutoMapper;
using MediatR;
using MusicLibrary.Application.Songs.Dtos;
using MusicLibrary.Domain.Repositories;

namespace MusicLibrary.Application.Songs.Queries.GetSongsForAlbum;

public class GetSongsForAlbumQueryHandler(IAlbumsRepository albumsRepository, IMapper mapper) : IRequestHandler<GetSongsForAlbumQuery, IEnumerable<SongDto>>
{
    public async Task<IEnumerable<SongDto>> Handle(GetSongsForAlbumQuery request, CancellationToken cancellationToken)
    {
        var album = await albumsRepository.GetByIdAsync(request.AlbumId);

        if (album == null)
        {
            throw new Exception("Album not found");
        }

        var results = mapper.Map<IEnumerable<SongDto>>(album.Songs);

        return results;
    }
}
