using MusicLibrary.Application.Songs.Dtos;
using MusicLibrary.Domain.Entities;

namespace MusicLibrary.Application.Albums.Dtos;

public class AlbumDto
{
    public Guid AlbumId { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public Guid ArtistId { get; set; }
    public string ArtistName { get; set; } = null!;

    public List<SongDto> Songs { get; set; } = [];
}
