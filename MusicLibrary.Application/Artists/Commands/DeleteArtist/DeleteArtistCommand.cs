using MediatR;

namespace MusicLibrary.Application.Artists.Commands.DeleteArtist;

public class DeleteArtistCommand(Guid artistId) : IRequest
{
    public Guid ArtistId { get; } = artistId;
}
