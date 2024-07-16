using AutoMapper;
using MediatR;
using MusicLibrary.Application.Songs.Dtos;
using MusicLibrary.Domain.Repositories;

namespace MusicLibrary.Application.Songs.Queries.GetAllSongs;

public class GetAllSongsQueryHandler(ISongsRepository songsRepository, IMapper mapper) : IRequestHandler<GetAllSongsQuery, IEnumerable<SongWithArtistAndAlbumDto>>
{
    public async Task<IEnumerable<SongWithArtistAndAlbumDto>> Handle(GetAllSongsQuery request, CancellationToken cancellationToken)
    {
        var songs = await songsRepository.GetAllAsync();
        var results = mapper.Map<IEnumerable<SongWithArtistAndAlbumDto>>(songs);

        return results;
    }
}