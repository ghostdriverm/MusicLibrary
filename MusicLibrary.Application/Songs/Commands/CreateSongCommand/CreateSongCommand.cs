using MediatR;

namespace MusicLibrary.Application.Songs.Commands.CreateSongCommand;

public class CreateSongCommand : IRequest<Guid>
{
    public Guid SongId { get; set; }
    public string Title { get; set; } = default!;
    public string Length { get; set; } = default!;

    public Guid AlbumId { get; set; } = default!;
}
