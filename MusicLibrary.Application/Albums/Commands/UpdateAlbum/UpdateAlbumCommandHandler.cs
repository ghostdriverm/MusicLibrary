using MediatR;
using MusicLibrary.Domain.Repositories;

namespace MusicLibrary.Application.Albums.Commands.UpdateAlbum;

public class UpdateAlbumCommandHandler(IAlbumsRepository albumRepository) : IRequestHandler<UpdateAlbumCommand>
{

    public async Task Handle(UpdateAlbumCommand command, CancellationToken cancellationToken)
    {
        var album = await albumRepository.GetByIdAsync(command.AlbumId);

        if (album == null) throw new Exception("Album not found!");

        album.Title = command.Title;
        album.Description = command.Description;

        await albumRepository.SaveChanges();
    }

}
