using MediatR;
using MusicLibrary.Domain.Entities;
using MusicLibrary.Domain.Repositories;

namespace MusicLibrary.Application.Albums.Commands.CreateAlbum;

public class CreateAlbumCommandHandler(IAlbumsRepository albumRepository,
    IArtistsRepository artistsRepository) : IRequestHandler<CreateAlbumCommand, Guid>
{

    public async Task<Guid> Handle(CreateAlbumCommand command, CancellationToken cancellationToken)
    {
        var artist = await artistsRepository.GetByIdAsync(command.ArtistId);

        if (artist == null) throw new Exception("Artist not found!");

        var album = new Album
        {
            AlbumId = Guid.NewGuid(),
            Title = command.Title,
            Description = command.Description,
            ArtistId = command.ArtistId,

        };

        await albumRepository.Create(album);

        return album.AlbumId;
    }

}
