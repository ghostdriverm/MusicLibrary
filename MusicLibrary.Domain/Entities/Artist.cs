namespace MusicLibrary.Domain.Entities;

public class Artist
{
    public Guid ArtistId { get; set; }
    public string Name { get; set; } = default!;

    public List<Album> Albums { get; set; } = new();
}
