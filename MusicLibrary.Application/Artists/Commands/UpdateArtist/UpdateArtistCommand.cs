using MediatR;

namespace MusicLibrary.Application.Artists.Commands.UpdateArtist;

public class UpdateArtistCommand : IRequest
{
    public Guid ArtistId { get; set; }
    public string Name { get; set; } = default!;
}
