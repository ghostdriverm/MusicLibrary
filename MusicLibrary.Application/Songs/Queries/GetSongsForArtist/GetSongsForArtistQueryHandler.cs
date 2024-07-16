using AutoMapper;
using MediatR;
using MusicLibrary.Application.Songs.Dtos;
using MusicLibrary.Domain.Repositories;

namespace MusicLibrary.Application.Songs.Queries.GetSongsForArtist;

public class GetSongsForArtistQueryHandler(IArtistsRepository artistsRepository, ISongsRepository songsRepository, IMapper mapper) : IRequestHandler<GetSongsForArtistQuery, IEnumerable<SongDto>>
{
    public async Task<IEnumerable<SongDto>> Handle(GetSongsForArtistQuery request, CancellationToken cancellationToken)
    {
        var artist = await artistsRepository.GetByIdAsync(request.ArtistId);
        if (artist == null)
        {
            throw new Exception("Artist not found.");
        }

        var allSongs = await songsRepository.GetAllByArtistAsync(request.ArtistId);

        var results = mapper.Map<IEnumerable<SongDto>>(allSongs);

        return results;
    }
}
