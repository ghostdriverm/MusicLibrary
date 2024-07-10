namespace MusicLibrary.Domain.Entities;

public class Song
{
    public Guid Id { get; set; }
    public Guid? AlbumId { get; set; }
    public Guid ArtistId { get; set; }
    public string Title { get; set; } = default!;
    public string Length { get; set; } = default!;

    public Album? Album { get; set; }
    public Artist Artist { get; set; } = new();
}
