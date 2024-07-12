using MediatR;

namespace MusicLibrary.Application.Albums.Commands.UpdateAlbum;

public class UpdateAlbumCommand : IRequest
{
    public Guid AlbumId { get; set; }
    public string Title { get; set; } = string.Empty!;
    public string Description { get; set; } = string.Empty!;

}
