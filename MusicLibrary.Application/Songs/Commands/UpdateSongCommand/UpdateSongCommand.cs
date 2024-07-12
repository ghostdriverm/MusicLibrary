using MediatR;

namespace MusicLibrary.Application.Songs.Commands.UpdateSongCommand;

public class UpdateSongCommand : IRequest
{
    public Guid SongId { get; set; }
    public string Title { get; set; } = default!;
    public string Length { get; set; } = default!;

}
