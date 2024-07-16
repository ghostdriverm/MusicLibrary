using AutoMapper;
using MediatR;
using MusicLibrary.Application.Albums.Dtos;
using MusicLibrary.Domain.Repositories;

namespace MusicLibrary.Application.Albums.Queries.GetAlbumById;

public class GetAlbumByIdQueryHandler(IAlbumsRepository albumsRepository, IMapper mapper) : IRequestHandler<GetAlbumByIdQuery, AlbumDto>
{
    public async Task<AlbumDto> Handle(GetAlbumByIdQuery request, CancellationToken cancellationToken)
    {
        var album = await albumsRepository.GetByIdAsync(request.AlbumId);

        if (album == null)
        {
            throw new Exception("Album not found");
        }
        var albumDto = mapper.Map<AlbumDto>(album);
        return albumDto;
    }
}
