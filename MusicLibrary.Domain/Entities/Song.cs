namespace MusicLibrary.Domain.Entities;

public class Song
{
    public Guid SongId { get; set; }
    public string Title { get; set; } = default!;
    public string Length { get; set; } = default!;

    public Guid AlbumId { get; set; }
    public Album Album { get; set; } = null!;

}
