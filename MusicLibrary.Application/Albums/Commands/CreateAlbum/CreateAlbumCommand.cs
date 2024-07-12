using MediatR;

namespace MusicLibrary.Application.Albums.Commands.CreateAlbum;

public class CreateAlbumCommand : IRequest<Guid>
{
    public Guid ArtistId { get; set; }
    public Guid AlbumId { get; set; }
    public string Title { get; set; } = string.Empty!;
    public string Description { get; set; } = string.Empty!;

}
