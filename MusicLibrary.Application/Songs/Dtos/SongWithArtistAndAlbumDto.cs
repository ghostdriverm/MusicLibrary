
namespace MusicLibrary.Application.Songs.Dtos;

public class SongWithArtistAndAlbumDto
{
    public Guid SongId { get; set; }
    public string Title { get; set; } = default!;
    public string Length { get; set; } = default!;

    public Guid AlbumId { get; set; } = default!;
    public string AlbumName { get; set; } = default!;
    public Guid ArtistId { get; set; } = default!;
    public string ArtistName { get; set; } = default!;
}
