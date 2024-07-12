using MusicLibrary.Application.Songs.Dtos;

namespace MusicLibrary.Application.Albums.Dtos;

public class AlbumDto
{
    public Guid AlbumId { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public Guid ArtistId { get; set; }

    public List<SongDto> Songs { get; set; } = [];
}
