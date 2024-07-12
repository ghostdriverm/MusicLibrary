using MediatR;
namespace MusicLibrary.Application.Artists.Commands.CreateArtist;

public class CreateArtistCommand : IRequest<Guid>
{
    public string Name { get; set; } = default!;
}
