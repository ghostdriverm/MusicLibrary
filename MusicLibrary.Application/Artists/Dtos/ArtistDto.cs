using MusicLibrary.Application.Albums.Dtos;

namespace MusicLibrary.Application.Artists.Dtos;

public class ArtistDto
{
    public Guid ArtistId { get; set; }
    public string Name { get; set; } = default!;

    public List<AlbumDto> Albums { get; set; } = [];
}
