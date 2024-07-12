using AutoMapper;
using MediatR;
using MusicLibrary.Application.Artists.Dtos;
using MusicLibrary.Domain.Repositories;

namespace MusicLibrary.Application.Artists.Queries.GetArtistById;

public class GetArtistByIdQueryHandler(IArtistsRepository artistsRepository, IMapper mapper) : IRequestHandler<GetArtistByIdQuery, ArtistDto>
{
    public async Task<ArtistDto> Handle(GetArtistByIdQuery request, CancellationToken cancellationToken)
    {
        var artist = await artistsRepository.GetByIdAsync(request.ArtistId);

        if (artist == null) throw new Exception("Artist not found.");

        var artistDto = mapper.Map<ArtistDto>(artist);

        return artistDto;
    }
}
